begin transaction;

	-- Variable declarations
	declare @statuses table (
		[id] varchar(256), 
		[descr] varchar(256),
		[isComp] bit
	);

	-- Insert the required variables
	insert into @statuses ([id], [descr], [isComp]) values ('CANC', 'Canceled', 1);
	insert into @statuses ([id], [descr], [isComp]) values ('COMP', 'Completed', 1);
	insert into @statuses ([id], [descr], [isComp]) values ('INPRO', 'In Progress', 0);
	insert into @statuses ([id], [descr], [isComp]) values ('NEW', 'New', 0);
	insert into @statuses ([id], [descr], [isComp]) values ('START', 'Started', 0);	

	insert into Statuses ([Id], [Description], [IsCompleted])
	select s.[id], [descr], [isComp]
	from @statuses s
		left join Statuses s2 on s.id = s2.Id
	where s2.Id is null;

commit transaction;

select * from Statuses;