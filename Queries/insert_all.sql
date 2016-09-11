INSERT dbo.UserProfile ([UserName], [Salt], [PasswordHash])
VALUES (N'crackoff', 0x0, HASHBYTES('sha1', '123'));

INSERT dbo.UserProfile ([UserName], [Salt], [PasswordHash])
VALUES (N'елбонций', 0xABCDEF1234, HASHBYTES('sha1', '321роро'));

SELECT * FROM dbo.UserProfile

INSERT dbo.Device (UserProfileId, DeviceKey, ChangeKey, Name, Units)
VALUES (1, 'd5GnjP0bdX', '4tTMgJX7mBWymRFUgfXjcgioRSrr2LE2F5s4EsLmmsKJ', 'Super Puper Device', 'Celsium')

DECLARE @a INT = 0;
WHILE @a < 100
BEGIN
	INSERT dbo.Signal(DeviceId, SignalValue, SignalTime)
	SELECT 1
	, CAST(RAND() * 100 - 30 AS DECIMAL(10,2))
	, GETUTCDATE();

	SET @a = @a + 1;
END;

SELECT * FROM dbo.Signal;

INSERT dbo.Dashboard (UserProfileId, Name, Type)
VALUES (1, 'My dashboard', '1')

INSERT dbo.DashboardDevice VALUES(1,1)
