CREATE TABLE [dbo].[password_tokens]
(
	[token] VARCHAR(256) NOT NULL,
	[user_id] INT NOT NULL,
	[expires_at] DATETIME NOT NULL,
	[created_at] DATETIME NOT NULL, 
    CONSTRAINT [pk_password_tokens] PRIMARY KEY CLUSTERED ([token] ASC),
	CONSTRAINT [user_id] FOREIGN KEY ([user_id]) REFERENCES [users]([user_id]) ON DELETE CASCADE ON UPDATE CASCADE
)
GO
