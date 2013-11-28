CREATE TABLE [dbo].[tags]
(
	[tag_id] INT NOT NULL IDENTITY(1, 1), 
    [description] VARCHAR(256) NOT NULL,
	[slug] VARCHAR(256) NOT NULL,
	[is_active] BIT NOT NULL DEFAULT((1)), 
    [created_at] DATETIME NOT NULL, 
    [updated_at] DATETIME NOT NULL, 
    [version] ROWVERSION NOT NULL
	CONSTRAINT [pk_tags] PRIMARY KEY CLUSTERED ([tag_id] ASC)
)
GO

CREATE UNIQUE INDEX [tags_description] ON [dbo].[tags] ([description])
GO

CREATE UNIQUE INDEX [tags_slug] ON [dbo].[tags] ([slug])
GO
