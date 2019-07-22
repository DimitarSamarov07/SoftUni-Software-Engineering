using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private double width;
        private double height;

        private double Width
        {
            get => width;
            set
            {
                width = value;
            }
        }

        private double Height
        {
            get => height;
            set
            {
                height = value;
            }
        }

        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }
        public override double CalculatePerimeter()
        {
            return Width * 2 + Height * 2;

        }

        public override double CalculateArea()
        {
            return Width * Height;
        }

        public sealed override string Draw()
        {
            return base.Draw() + "Rectangle";
        }
    }
}
