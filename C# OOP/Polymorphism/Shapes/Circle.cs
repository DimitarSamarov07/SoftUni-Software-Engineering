using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Circle : Shape
    {
        private double radius;

        public Circle(double radius)
        :base()
        {
            this.Radius = radius;
        }

        public double Radius
        {
            get => radius;
            private set
            {
                if (value>0)
                {
                    radius = value;
                }
                else
                {
                    throw new NullReferenceException();
                }
                
            }
        
        }

        public override double CalculatePerimeter()
        {
            return 2 * Math.PI * Radius;
        }

        public override double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }

        public override string Draw()
        {
            return base.Draw() + "Circle";
        }
    }
}
