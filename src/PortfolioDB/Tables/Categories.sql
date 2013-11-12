﻿CREATE TABLE [dbo].[Categories]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1), 
    [Description] VARCHAR(256) NOT NULL,
	[IsActive] BIT NOT NULL DEFAULT((1)), 
    [CreatedAt] DATETIME NOT NULL, 
    [UpdatedAt] DATETIME NOT NULL, 
    [Version] ROWVERSION NOT NULL
)
