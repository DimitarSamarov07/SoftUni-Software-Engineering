using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViceCity.Core.Contracts;
using ViceCity.Models.Guns;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Neghbourhoods;
using ViceCity.Models.Players;
using ViceCity.Models.Players.Contracts;

namespace ViceCity.Core
{
    public class Controller : IController
    {
        private List<CivilPlayer> civilPlayers;
        private MainPlayer mainPlayer;
        private List<IGun> guns;


        public Controller()
        {
            civilPlayers = new List<CivilPlayer>();
            guns = new List<IGun>();
            mainPlayer = new MainPlayer();
        }
        public string AddPlayer(string name)
        {
            CivilPlayer toAdd = new CivilPlayer(name);
            civilPlayers.Add(toAdd);
            return $"Successfully added civil player: {name}!";
        }
        //AddPlayer Command
        //Parameters
        //•	Name – string 
        //    Functionality
        //Creates a civil player with the given name.
        //    The method should return the following message:
        //•	"Successfully added civil player: {civilPlayerName}!"

        public string AddGun(string type, string name)
        {
            IGun gunToAdd = null;
            if (type == "Pistol")
            {
                gunToAdd = new Pistol(name);
            }

            if (type == "Rifle")
            {
                gunToAdd = new Rifle(name);
            }
            else
            {
                return "Invalid gun type!";
            }
            guns.Add(gunToAdd);
            return $"Successfully added {name} of type: {type}";
        }
        //AddGun Command
        //Parameters
        //•	Type - string
        //•	Name - string
        //    Functionality
        //Creates a gun with the provided type and name. 
        //    If the gun type is invalid, the method should return the following message:
        //•	"Invalid gun type!"
        //If the gun type is correct, keep the gun and return the following message:
        //•	"Successfully added {name} of type: {type}". 

        public string AddGunToPlayer(string name)
        {
            if (guns.Count == 0)
            {
                return "There are no guns in the queue!";
            }

            IGun toAdd = guns.FirstOrDefault();
            if (name == "Vercetti")
            {
                mainPlayer.GunRepository.Add(toAdd);
                return $"Successfully added {toAdd.Name} to the Main Player: Tommy Vercetti";
            }

            CivilPlayer player = civilPlayers.FirstOrDefault(x => x.Name == name);
            if (player == null)
            {
                return "Civil player with that name doesn't exists!";
            }
            player.GunRepository.Add(toAdd);
            return $"Successfully added {toAdd.Name} to the Civil Player: {player.Name}";
        }

        public string Fight()
        {
            int count = civilPlayers.Count(x => !x.IsAlive);
            GangNeighbourhood gang = new GangNeighbourhood();
            StringBuilder sb = new StringBuilder();
            if (this.mainPlayer.GunRepository.Models.Count == 0 && this.civilPlayers.All(x => x.GunRepository.Models.Count == 0))
            {
                sb.AppendLine("Everything is okay!");
            }
            else
            {
                gang.Action(mainPlayer,civilPlayers.ToArray());
                sb.AppendLine("A fight happened:");
                sb.AppendLine($"Tommy live points: {mainPlayer.LifePoints}!");
                sb.AppendLine($"Tommy has killed: {civilPlayers.Count(x => x.IsAlive)} players!");
                sb.AppendLine($"Left Civil Players: {civilPlayers.Count(x => !x.IsAlive)}!");
            }

            return sb.ToString();
        }
    }
}
