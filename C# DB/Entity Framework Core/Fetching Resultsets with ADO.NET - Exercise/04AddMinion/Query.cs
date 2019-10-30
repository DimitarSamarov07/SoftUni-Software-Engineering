using System;
using System.Collections.Generic;
using System.Text;

namespace _04AddMinion
{
    public static class Query
    {
        public const string TakeTownId = "SELECT Id FROM Towns WHERE Name = @name";
        public const string TakeMinionId = "SELECT Id FROM Minions WHERE Name = @name AND Age = @age";
        public const string TakeVillainId = "SELECT Id FROM Villains WHERE Name = @name";
        public const string TownInsertQuery = "INSERT INTO Towns (Name) VALUES (@townName)";
        public const string MinionInsertQuery = "INSERT INTO Minions (Name, Age, TownId) VALUES (@name, @age, @townId)";
        public const string VillainInsertQuery = "INSERT INTO Villains (Name, EvilnessFactorId) VALUES (@villainName, 4)";
        public const string MinionsVillainsInsertQuery = "INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@minionId, @villainId)";

    }
}
