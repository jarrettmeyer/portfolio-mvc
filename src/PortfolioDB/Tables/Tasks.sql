CREATE TABLE [dbo].[tasks]
(
	[task_id] INT NOT NULL IDENTITY(1, 1),
	[title] VARCHAR(256) NOT NULL DEFAULT '',
	[description] TEXT NOT NULL,		
	[due_on] DATETIME NULL,
	[is_completed] BIT NOT NULL,
	[completed_at] DATETIME NULL,
	[created_at] DATETIME NOT NULL DEFAULT GETUTCDATE(),
	[updated_at] DATETIME NOT NULL DEFAULT GETUTCDATE(), 
    [version] ROWVERSION NOT NULL, 
	CONSTRAINT [pk_tasks] PRIMARY KEY CLUSTERED ([task_id] ASC)
)
GO

CREATE INDEX [tasks_is_completed] ON [dbo].[tasks] ([is_completed])
GO
