using IoT.Dashboard.Interfaces;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Newtonsoft.Json;
using System;
using System.IO;

namespace IoT.Dashboard.SignalsQueue
{
    public class SignalsQueueProvider : ISignalsQueueProvider
    {
        public SignalsQueueProvider()
        {
            _signalsQueue = CreateQueue();
        }

        public void AddSignalToQueue(string deviceKey, decimal signalValue, DateTimeOffset signalTime)
        {
            var message = SerializeSignal(Tuple.Create(deviceKey, signalValue, signalTime));

            _signalsQueue.AddMessage(new CloudQueueMessage(message));
        }

        public bool GetSignalFromQueue(out string deviceKey, out decimal signalValue, out DateTimeOffset signalTime)
        {
            var message = _signalsQueue.GetMessage(visibilityTimeout: TimeSpan.FromMilliseconds(500));
            if (message != null)
            {
                var signal = DeserializeSignal(message.AsString);
                deviceKey = signal.Item1;
                signalValue = signal.Item2;
                signalTime = signal.Item3;

                _signalsQueue.DeleteMessage(message);

                return true;
            }

            deviceKey = default(string);
            signalValue = default(decimal);
            signalTime = default(DateTimeOffset);

            return false;
        }

        public void Dispose()
        {
        }

        private CloudQueue CreateQueue()
        {
            var storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("QueueConnectionString"));
            var queueName = CloudConfigurationManager.GetSetting("QueueName");

            var queueClient = storageAccount.CreateCloudQueueClient();
            var queue = queueClient.GetQueueReference(queueName);

            queue.CreateIfNotExists();

            return queue;
        }

        private string SerializeSignal(Tuple<string, decimal, DateTimeOffset> signal)
        {
            var stringWriter = new StringWriter();
            var jsonTextWriter = new JsonTextWriter(stringWriter);
            var serializer = new JsonSerializer();
            serializer.Serialize(jsonTextWriter, Tuple.Create(signal.Item1, signal.Item2, signal.Item3));

            return stringWriter.ToString();
        }

        private Tuple<string, decimal, DateTimeOffset> DeserializeSignal(string serialized)
        {
            var textReader = new StringReader(serialized);
            var jsonTextReader = new JsonTextReader(textReader);
            var serializer = new JsonSerializer();

            return serializer.Deserialize<Tuple<string, decimal, DateTimeOffset>>(jsonTextReader);
        }

        private CloudQueue _signalsQueue;
    }
}
