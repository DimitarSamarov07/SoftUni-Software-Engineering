using System;
using System.Collections.Generic;
using System.Text;

namespace Class_Box_Data
{
    class Box
    {

        private double length;
        private double width;
        private double height;


        public double Length
        {
            get { return this.length; }
            private set
            {
                if (value > 0)
                {
                    this.length = value;
                }

                else
                {
                    Exception ex =new ArgumentException("Length cannot be zero or negative.");
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }

            }
        }

        public double Width
        {
            get { return this.width; }
            private set
            {
                if (value > 0)
                {
                    this.width = value;
                }

                else
                {
                    Exception ex = new ArgumentException("Width cannot be zero or negative.");
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }

            }
        }

        public double Height
        {
            get { return this.height; }
            private set
            {
                if (value > 0)
                {
                    this.height = value;
                }

                else
                {
                    Exception ex = new ArgumentException("Height cannot be zero or negative.");
                    Console.WriteLine(ex.Message.TrimEnd());
                    Environment.Exit(0);
                }

            }
        }

        public Box(double length, double width, double height)
        {

            this.Length = length;
            this.Width = width;
            this.Height = height;
            QuickMaths();
        }

        private void QuickMaths()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Surface Area - {2 * Length * Width + 2 * Length * Height + 2 * Width * Height:f2}" + Environment.NewLine);
            sb.Append($"Lateral Surface Area - {2 * Length * Height + 2 * Width * Height:f2}" + Environment.NewLine);
            sb.Append($"Volume - {Length * Width * Height:f2}");
            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}
