CREATE TABLE [dbo].[Tasks]
(
	[Id] INT NOT NULL IDENTITY(1, 1),
	[Title] VARCHAR(256) NOT NULL DEFAULT '',
	[Description] TEXT NOT NULL,
	[CategoryId] INT,
	[CurrentStatus] VARCHAR(256),
	[DueOn] DATETIME,
	[IsCompleted] BIT,
	[CreatedAt] DATETIME NOT NULL DEFAULT GETUTCDATE(),
	[UpdatedAt] DATETIME NOT NULL DEFAULT GETUTCDATE(), 
    [Version] ROWVERSION NOT NULL, 
	CONSTRAINT [PK_Tasks] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Tasks_Categories] FOREIGN KEY ([CategoryId]) REFERENCES [Categories]([Id]), 
    CONSTRAINT [FK_Tasks_Statuses] FOREIGN KEY ([CurrentStatus]) REFERENCES [Statuses]([Id])
)
GO

CREATE INDEX [IX_Tasks_IsCompleted] ON [dbo].[Tasks] ([IsCompleted])
GO

CREATE INDEX [IX_Tasks_CurrentStatus] ON [dbo].[Tasks] ([CurrentStatus])
GO