IF NOT Exists (SELECT 1 FROM Items WHERE [Name] = 'Chain Mail') BEGIN
    INSERT INTO Items
    (ItemId, [Name], [Description])
    VALUES
    (NEWID(), 'Chain Mail', 'Armor Made From Chain Links'),
	(NEWID(), 'Long Sword', 'One Handed Sword'),
	(NEWID(), 'Basic Cloak', 'A basic linnen cloak')

    INSERT INTO InventoryItem (ItemId, CharacterId, Notes)
        SELECT (SELECT TOP 1 ItemId From Items WHERE [Name] = 'Basic Cloak') as ItemId,
               CharacterId, 
               'Free Cloak' as Notes
        FROM [Characters]
END