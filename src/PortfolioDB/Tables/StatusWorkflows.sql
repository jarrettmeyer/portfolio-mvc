CREATE TABLE [dbo].[StatusWorkflows]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	[FromStatus] VARCHAR(256),
	[ToStatus] VARCHAR(256),
	[CreatedAt] DATETIME NOT NULL DEFAULT GETUTCDATE(),
	[Version] ROWVERSION,
	CONSTRAINT [FK_StatusWorkflows_Statuses_From] FOREIGN KEY ([FromStatus]) REFERENCES [Statuses]([Id]),
	CONSTRAINT [FK_StatusWorkflows_Statuses_To] FOREIGN KEY ([ToStatus]) REFERENCES [Statuses]([Id])
)
GO

CREATE UNIQUE INDEX [IX_StatusWorkflows_UniqueFromTo] ON [dbo].[StatusWorkflows] ([FromStatus], [ToStatus])
GO
