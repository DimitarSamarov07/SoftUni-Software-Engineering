using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Neghbourhoods.Contracts;
using ViceCity.Models.Players.Contracts;

namespace ViceCity.Models.Neghbourhoods
{
    public class GangNeighbourhood : INeighbourhood
    {
        public void Action(IPlayer mainPlayer, ICollection<IPlayer> civilPlayers)
        {
            IGun gun = mainPlayer.GunRepository.Models.FirstOrDefault();
            bool secondTurn = gun==null;
            if (!secondTurn)
            {
                foreach (var civilPlayer in civilPlayers)
                {
                    while (!civilPlayer.IsAlive||!gun.CanFire)
                    {
                        int damage =  gun.Fire();
                        civilPlayer.TakeLifePoints(damage);
                    }

                    if (!gun.CanFire)
                    {
                        break;
                    }
                }
            }
            if (secondTurn)
            {
                
                foreach (var player in civilPlayers.Where(x=>x.IsAlive))
                {
                    gun = player.GunRepository.Models.FirstOrDefault();
                    while (!gun.CanFire||!mainPlayer.IsAlive)
                    {
                        
                    }
                }
            }
        }
        //void Action(IPlayer mainPlayer, ICollection<IPlayer> civilPlayers)
        //That's the most interesting method. 
        //    The main player starts shooting at all the civil players.

        // When he starts shooting at a civil player, the following rules apply:
        //•	He takes a gun from his guns.
        //•	Every time he shoots, he takes
        //life points from the civil player, which are equal
        //to the bullets that the current gun shoots when the trigger is pulled.
        //•	If the barrel of his gun becomes empty, he reloads from
        //his bullets stock and continues shooting with the current gun, until he uses all of its bullets.
        //•	If his gun runs out of total bullets, he takes the next
        //gun he has and continues shooting.
        //•	He shoots at the current civil player until he / she is alive. 
        //•	If the civil player dies, he starts shooting at the next one.
        //•	The main player stops shooting only if he runs out of guns or until all the civil players are dead.

        //    The civil players (the ones that have stayed alive after the main player's attack) attack second. They start shooting at him one after another and the following rules apply:
        //•	A civil player takes one of his guns and starts shooting at the main player.
        //•	Every time he shoots, he takes life points from the main player, which are equal to the bullets that the current gun shoots when the trigger is pulled.
        //•	If the barrel of his gun becomes empty, he reloads from his bullets stock and continues shooting with the current gun, until he uses all of its bullets.
        //•	If his current gun runs out of all its bullets, he takes the next gun he has and continues shooting.
        //•	If a civil player runs out of guns, the next civil player begins shooting.
        //•	If the main player dies, the whole action ends.
    }
}
