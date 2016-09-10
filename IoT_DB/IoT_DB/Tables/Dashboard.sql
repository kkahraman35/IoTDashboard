CREATE TABLE dbo.Dashboard
(
  DashboardId INT IDENTITY NOT NULL
, UserProfileId INT NOT NULL
, Name VARCHAR(50) NOT NULL
, Type VARCHAR(50) NOT NULL

, CONSTRAINT PK_Dashboard PRIMARY KEY CLUSTERED (DashboardId)
, CONSTRAINT FK_Dashboard_UserProfile FOREIGN KEY (UserProfileId) REFERENCES dbo.UserProfile(UserProfileId)
)
