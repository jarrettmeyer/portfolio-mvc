CREATE TABLE [dbo].[users]
(
	[user_id] INT NOT NULL IDENTITY(1,1),
	[username] VARCHAR(256) NOT NULL,
	[hashed_password] VARCHAR(256) NOT NULL,
	[last_logon_at] DATETIME NULL,
	[is_active] BIT NOT NULL,
	[created_at] DATETIME NOT NULL,
	[updated_at] DATETIME NOT NULL,
	[version] ROWVERSION NOT NULL,
	CONSTRAINT [pk_users] PRIMARY KEY CLUSTERED ([user_id] ASC)
)
GO

CREATE UNIQUE INDEX [unique_username] on [users] ([username])
GO