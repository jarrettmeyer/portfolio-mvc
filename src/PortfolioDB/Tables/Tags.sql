CREATE TABLE [dbo].[tags]
(
	[tag_id] VARCHAR(256) NOT NULL,
    [description] VARCHAR(256) NOT NULL,	
	[is_active] BIT NOT NULL DEFAULT((1)), 
    [created_at] DATETIME NOT NULL, 
    [updated_at] DATETIME NOT NULL, 
    [version] ROWVERSION NOT NULL
	CONSTRAINT [pk_tags] PRIMARY KEY CLUSTERED ([tag_id] ASC)
)
GO

CREATE UNIQUE INDEX [tags_description] ON [dbo].[tags] ([description])
GO
