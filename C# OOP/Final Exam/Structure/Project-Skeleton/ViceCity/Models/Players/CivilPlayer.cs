using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Players
{
    public class CivilPlayer : Player
    {
        //CivilPlayer
        //    Has 50 initial life points.
        //    Constructor should take the following values upon initialization:
        //string name

        public CivilPlayer(string name)
            : base(name, 50)
        {
        }
    }
}
