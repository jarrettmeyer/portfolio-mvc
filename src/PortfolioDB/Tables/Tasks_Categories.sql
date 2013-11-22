CREATE TABLE [dbo].[Tasks_Categories]
(
	[TaskId] INT NOT NULL,
    [CategoryId] INT NOT NULL, 
    CONSTRAINT [PK_Tasks_Categories] PRIMARY KEY CLUSTERED ([TaskId], [CategoryId])
)
GO
