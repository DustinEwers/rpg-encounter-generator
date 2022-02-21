IF NOT Exists (SELECT 1 FROM Items WHERE [Name] = 'Chain Mail') BEGIN
    INSERT INTO Items
    (ItemId, [Name], [Description])
    VALUES
    ('D2EE8A8B-73F7-43EC-80DC-1A6E2FB5F585', 'Chain Mail', 'Armor Made From Chain Links'),
	('D3F03FB0-072A-481F-8C6C-4A45BC6F2C0F', 'Long Sword', 'One Handed Sword'),
	('A3AC5D10-F16B-4E64-A8E9-56CE761AC6B0', 'Basic Cloak', 'A basic linnen cloak')

    INSERT INTO InventoryItem (ItemId, CharacterId, Notes)
        SELECT (SELECT TOP 1 ItemId From Items WHERE [Name] = 'Basic Cloak') as ItemId,
               CharacterId, 
               'Free Cloak' as Notes
        FROM [Characters]
END