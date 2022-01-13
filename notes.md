# Super Over-Engineered Solo Roleplaying Encounter Generator

This is a demo project that simulates a DM. 
It generates encounters and you roll your way through them. 

## Projects

UI - Some Front End Framework that Calls an API

## Objects to Keep Track Of (and service boundaries)
Charisma
Character
    Stats
    Backstory
    Inventory
        Name
        Description
        Damage

---------------------------

Item Registry
    Description
    Monetary Value

---------------------------

Encounters
    Name
    Description
    Entities (monsters or people)

NPCs
    Name
    Stats
    Type
    Inventory

Available Monsters (and their Stats)
    Name
    Size
    Armor Class
    Description
    CR / XP
    Treasure
    Attacks (1 to many)
        Description
        Damage
        + to Hit

---------------------------

Maps
    Locations
    Coordinates

---------------------------

Game
    Current State
    Adventure Journal
        Encounters
