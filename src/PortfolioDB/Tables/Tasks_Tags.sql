CREATE TABLE [dbo].[tasks_tags]
(
	[task_id] INT NOT NULL,
    [tag_id] INT NOT NULL, 
    CONSTRAINT [pk_tasks_tags] PRIMARY KEY CLUSTERED ([task_id], [tag_id])
)
GO
