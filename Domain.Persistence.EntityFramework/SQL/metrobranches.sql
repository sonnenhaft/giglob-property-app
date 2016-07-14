IF NOT EXISTS(SELECT NULL FROM [dbo].[MetroBranches])
BEGIN
  DECLARE @name INT;
select @name = Id from [dbo].[Cities] WHERE Name='Москва';
 INSERT INTO [dbo].[MetroBranches]
            ([HexColor],[CityId])
     VALUES
	 ('ffff00',@name),
     ('6aa84f',@name),
     ('ff9900',@name),
     ('9fc5e8',@name),
     ('b7b7b7',@name),
     ('0000ff',@name),
     ('a64d79',@name),
     ('00ff00',@name),
     ('ff0000',@name),
     ('783f04',@name)		
END