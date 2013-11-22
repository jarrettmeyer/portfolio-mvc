CREATE TABLE [dbo].[Categories]
(
	[Id] INT NOT NULL IDENTITY(1, 1), 
    [Description] VARCHAR(256) NOT NULL,
	[IsActive] BIT NOT NULL DEFAULT((1)), 
    [CreatedAt] DATETIME NOT NULL, 
    [UpdatedAt] DATETIME NOT NULL, 
    [Version] ROWVERSION NOT NULL
	CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED ([Id] ASC)
)
GO

CREATE UNIQUE INDEX [IX_Categories_Description] ON [dbo].[Categories] ([Description])
GO
