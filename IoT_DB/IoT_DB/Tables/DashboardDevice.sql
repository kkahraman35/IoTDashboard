CREATE TABLE dbo.DashboardDevice
(
  DashboardId INT NOT NULL
, DeviceId INT NOT NULL

, CONSTRAINT PK_DashboardDevice PRIMARY KEY CLUSTERED (DashboardId, DeviceId)
, CONSTRAINT FK_DashboardDevice_Dashboard FOREIGN KEY (DashboardId) REFERENCES dbo.Dashboard(DashboardId)
, CONSTRAINT FK_DashboardDevice_Ddevice FOREIGN KEY (DeviceId) REFERENCES dbo.Device(DeviceId)
)
