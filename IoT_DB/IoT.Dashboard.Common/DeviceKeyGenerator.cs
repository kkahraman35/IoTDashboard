using System;
using System.Numerics;
using System.Security.Cryptography;

namespace IoT.Dashboard.Common
{
    public class DeviceKeyGenerator : IDisposable
    {
        public DeviceKeyGenerator()
        {
            _randomDataGenerator = new RNGCryptoServiceProvider();
        }

        public string GetRandomChangeKey()
        {
            var bytes = GetRandomBytes(32);
            var number = new BigInteger(bytes);

            return EncodeBase58(number);
        }

        public string GetRandomDeviceKey()
        {
            var bytes = GetRandomBytes(6);
            var number = new BigInteger(bytes);

            return EncodeBase58(number);
        }

        private byte[] GetRandomBytes(int count)
        {
            var bytes = new byte[count];
            _randomDataGenerator.GetBytes(bytes);
            bytes[bytes.Length - 1] &= 0x7F; //force sign bit to positive

            return bytes;
        }

        private string EncodeBase58(BigInteger data)
        {
            var result = string.Empty;
            while (data > 0)
            {
                var remainder = (int)(data % 58);
                data /= 58;
                result = _Base58Alphabet[remainder] + result;
            }

            return result;
        }

        public void Dispose()
        {
            _randomDataGenerator.Dispose();
        }

        private readonly RandomNumberGenerator _randomDataGenerator;
        private const string _Base58Alphabet = "123456789abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNPQRSTUVWXYZ";
    }
}
