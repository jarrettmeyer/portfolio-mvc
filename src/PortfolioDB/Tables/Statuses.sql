CREATE TABLE [dbo].[Statuses]
(
	[Id] VARCHAR(256) NOT NULL PRIMARY KEY, 
    [Description] VARCHAR(256) NOT NULL, 
    [IsCompleted] BIT NOT NULL,
	[IsDefaultStatus] BIT NOT NULL DEFAULT 0
)
