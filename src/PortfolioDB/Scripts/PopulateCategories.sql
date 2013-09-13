begin transaction;

	-- Variable declarations
	declare @categoryDescriptions table ([descr] varchar(256));

	-- Insert the required variables
	insert into @categoryDescriptions ([descr]) values ('Around the House');
	insert into @categoryDescriptions ([descr]) values ('Client Research');
	insert into @categoryDescriptions ([descr]) values ('Corporate Blogging');
	insert into @categoryDescriptions ([descr]) values ('Wireframing');

	insert into Categories ([Description], [CreatedAt], [UpdatedAt])
	select [descr], GETUTCDATE(), GETUTCDATE()
	from @categoryDescriptions cd
		left join Categories c on cd.descr = c.Description
	where c.Description is null;

commit transaction;

select * from Categories;