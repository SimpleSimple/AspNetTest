-- ≤Â»Î≤‚ ‘ ˝æ›
INSERT INTO OnlineStats(InsertTime, [Counter])
VALUES
(GETDATE(),200),

INSERT INTO OnlineStats(InsertTime, [Counter])
VALUES
(dateadd(hour,-1,getdate()), 270),
(dateadd(hour,-2,getdate()), 320)


INSERT INTO OnlineStats(InsertTime, [Counter])
VALUES
(DATEADD(hour, -12, getdate()), 500),
(DATEADD(hour, -10, getdate()), 530),
(DATEADD(hour, -8, getdate()), 660),
(DATEADD(hour, -7, getdate()), 680)