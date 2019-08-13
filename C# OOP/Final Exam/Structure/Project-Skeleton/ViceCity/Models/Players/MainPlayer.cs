using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Players
{
    public class MainPlayer:Player
    {
        //MainPlayer
        //    Has 100 initial life points and the main player has only one name "Tommy Vercetti".
        // The constructor should not take name and life points values upon initialization.


        public MainPlayer()
            : base("Tommy Vercetti", 100)
        {
        }
    }
}
