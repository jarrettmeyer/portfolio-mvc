CREATE TABLE [dbo].[Tags]
(
	[Id] INT NOT NULL IDENTITY(1, 1), 
    [Description] VARCHAR(256) NOT NULL,
	[Slug] VARCHAR(256) NOT NULL,
	[IsActive] BIT NOT NULL DEFAULT((1)), 
    [CreatedAt] DATETIME NOT NULL, 
    [UpdatedAt] DATETIME NOT NULL, 
    [Version] ROWVERSION NOT NULL
	CONSTRAINT [PK_Tags] PRIMARY KEY CLUSTERED ([Id] ASC)
)
GO

CREATE UNIQUE INDEX [IX_Tags_Description] ON [dbo].[Tags] ([Description])
GO

CREATE UNIQUE INDEX [IX_Tags_Slug] ON [dbo].[Tags] ([Slug])
GO
