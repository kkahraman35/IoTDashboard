﻿CREATE TABLE dbo.Device
(
  DeviceId INT IDENTITY NOT NULL
, UserProfileId INT NOT NULL
, Name NVARCHAR(50) NOT NULL
, Units NVARCHAR(50) NOT NULL

, CONSTRAINT PK_Device PRIMARY KEY CLUSTERED (DeviceId)
, CONSTRAINT FK_Device_UserProfile FOREIGN KEY (UserProfileId) REFERENCES dbo.UserProfile(UserProfileId)
)
