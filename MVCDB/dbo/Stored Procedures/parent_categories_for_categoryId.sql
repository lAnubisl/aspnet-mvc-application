CREATE PROCEDURE dbo.parent_categories_for_categoryId
	/*
	(
	@parameter1 int = 5,
	@parameter2 datatype OUTPUT
	)
	*/
	@id int
AS
	BEGIN
		Declare @table table(CategoryId bigint);
		Insert into @table Select CategoryId From Category Where CategoryId = @id;

		While exists(select CategoryId from Category where (CategoryId not in (select * from @table)) and (ParentCategoryId in (select * from @table))) 
			insert into @table 
			select CategoryId from Category 
				where (CategoryId not in (select * from @table))
				and (ParentCategoryId in (select * from @table)) 

		Select * from Category where CategoryId not in (select * from @table)
	END
	RETURN
