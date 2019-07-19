﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private double width;
        private double height;
        public double Width
        {
            get => width;
            private set
            {
                if (value > 0)
                {
                    width = value;
                }
                else
                {
                    throw new NullReferenceException();
                }
            }
        }

        public double Height
        {
            get => height;
            private set
            {
                if (value > 0)
                {
                    height = value;
                }
                else
                {
                    throw new NullReferenceException();
                }
            }
        }

        public Rectangle(double height, double width)
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

        public override string Draw()
        {
            return base.Draw() + "Rectangle";
        }
    }
}
