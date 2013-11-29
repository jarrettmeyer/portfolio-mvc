CREATE TABLE [dbo].[password_tokens]
(
	[token] VARCHAR(256) NOT NULL,
	[username] VARCHAR(256) NOT NULL,
	[expires_at] DATETIME NOT NULL,
	[created_at] DATETIME NOT NULL, 
    CONSTRAINT [pk_password_tokens] PRIMARY KEY CLUSTERED ([token] ASC),
	CONSTRAINT [username] FOREIGN KEY ([username]) REFERENCES [users]([username]) ON DELETE CASCADE ON UPDATE CASCADE
)
GO
