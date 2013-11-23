CREATE TABLE [dbo].[Tasks_Tags]
(
	[TaskId] INT NOT NULL,
    [TagId] INT NOT NULL, 
    CONSTRAINT [PK_Tasks_Tags] PRIMARY KEY CLUSTERED ([TaskId], [TagId])
)
GO
