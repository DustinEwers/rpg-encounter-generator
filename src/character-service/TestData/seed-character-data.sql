IF NOT Exists (SELECT 1 FROM Characters WHERE [FirstName] = 'Bob') BEGIN
    INSERT INTO [dbo].[Characters]
           ([CharacterId]
           ,[FirstName]
           ,[LastName]
           ,[Strength]
           ,[Dexterity]
           ,[Constitution]
           ,[Intelligence]
           ,[Wisdom]
           ,[Charisma]
           ,[Backstory])
     VALUES
           (NEWID(),'Bob','McAdventurer'
           ,10,12,13,14,15,12
           ,'Some Stuff Happened'),
           (NEWID(),'Jane','McAdventurer'
           ,10,12,13,14,15,12
           ,'Some Stuff Happened')
END
