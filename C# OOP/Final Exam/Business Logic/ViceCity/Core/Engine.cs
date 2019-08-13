using ViceCity.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.IO.Contracts;
using ViceCity.IO;

namespace ViceCity.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private Controller control;

        public Engine()
        {
            this.reader = new Reader();
            this.writer = new Writer();
            this.control=new Controller();
        }
        public void Run()
        {
            StringBuilder sb = new StringBuilder();
            while (true)
            {
                var input = reader.ReadLine().Split();
                if (input[0] == "Exit")
                {
                    writer.Write(sb.ToString());
                    Environment.Exit(0);
                }
                try
                {
                    if (input[0] == "AddPlayer")
                    {
                        sb.AppendLine(control.AddPlayer(input[1]));
                    }
                    else if (input[0] == "AddGun")
                    {
                        sb.AppendLine(control.AddGun(input[1], input[2]));
                    }
                    else if (input[0] == "AddGunToPlayer")
                    {
                        sb.AppendLine(control.AddGunToPlayer(input[1]));
                    }
                    else if (input[0] == "Fight")
                    {
                        sb.AppendLine(control.Fight());
                    }            
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
                
            }
            
        }
    }
}
