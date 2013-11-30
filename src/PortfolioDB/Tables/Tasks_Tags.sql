CREATE TABLE [dbo].[tasks_tags]
(
	[task_id] INT NOT NULL,
    [tag_id] INT NOT NULL, 
    CONSTRAINT [pk_tasks_tags] PRIMARY KEY CLUSTERED ([task_id], [tag_id]), 
    CONSTRAINT [task_id] FOREIGN KEY ([task_id]) REFERENCES [tasks]([task_id]) ON DELETE CASCADE,
	CONSTRAINT [tag_id] FOREIGN KEY ([tag_id]) REFERENCES [tags]([tag_id]) ON DELETE CASCADE ON UPDATE CASCADE
)
GO

