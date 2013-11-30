CREATE TABLE [dbo].[tags]
(
	[tag_id] INT NOT NULL IDENTITY(1, 1),
	[slug] VARCHAR(256) NOT NULL,
    [description] VARCHAR(256) NOT NULL,	
	[is_active] BIT NOT NULL DEFAULT((1)), 
    [created_at] DATETIME NOT NULL DEFAULT GETUTCDATE(),
    [updated_at] DATETIME NOT NULL DEFAULT GETUTCDATE(), 
    [version] ROWVERSION NOT NULL
	CONSTRAINT [pk_tags] PRIMARY KEY CLUSTERED ([tag_id] ASC)
)
GO

CREATE UNIQUE INDEX [unique_slug] on [dbo].[tags] ([slug])
GO

CREATE UNIQUE INDEX [unique_description] ON [dbo].[tags] ([description])
GO
