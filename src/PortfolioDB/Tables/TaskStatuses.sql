CREATE TABLE [dbo].[TaskStatuses]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	[TaskId] INT NOT NULL,
	[Status] VARCHAR(256) NOT NULL,
	[IsCompleted] BIT NOT NULL,
	[Comment] VARCHAR(MAX),
	[IPAddress] VARCHAR(32) NULL,
	[CreatedAt] DATETIME NOT NULL, 
    [Version] ROWVERSION NOT NULL, 
    CONSTRAINT [FK_TaskStatuses_Tasks] FOREIGN KEY ([TaskId]) REFERENCES [Tasks]([Id]),
	CONSTRAINT [FK_TaskStatuses_Statuses] FOREIGN KEY ([Status]) REFERENCES [Statuses]([Id])
)
