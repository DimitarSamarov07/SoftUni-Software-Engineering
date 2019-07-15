using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace Pizza_Calories
{
    public class Dough
    {
        private double grams;
        private double flourTypeValue;
        //lowerFlour types
        private const double White = 1.5;
        private const double Wholegrain = 1.0;
        //End
        private double bakingTechniqueValue;
        //Techniques
        private const double Crispy = 0.9;
        private const double Homemade = 1.0;
        private const double Chewy = 1.1;
        //End

        public Dough(string flourType, string bakingTechnique, double grams)
        {
            SetFlourAndTechnique(flourType,bakingTechnique);
            this.Grams = grams;
        }

        public double TotalCalories => (grams * 2) * bakingTechniqueValue * flourTypeValue;

        private double FlourTypeValue
        {
            get => flourTypeValue;
            set { flourTypeValue = value; }

        }

        public double BakingTechniqueValue
        {
            get => bakingTechniqueValue;
            set { bakingTechniqueValue = value; } 

        }

        public double Grams
        {
            get => grams;
            private set
            {
                if (value >= 1 && value <= 200)
                {
                    grams = value;
                }

                else
                {
                    DoughException exc = new DoughException("gramsOverflow");
                }
            }

        }

        private void SetFlourAndTechnique(string flour, string technique)
        {
            double flourValueToSet = 12;
            double techniqueValueToSet = 13;
            string lowerFlour = flour.ToLower();
            string lowerTechnique = technique.ToLower();
            if (lowerFlour=="white")
            {
                flourValueToSet = White;
            }

            else if (lowerFlour=="wholegrain")
            {
                flourValueToSet = Wholegrain;
            }
            else
            {
                DoughException exc = new DoughException("typeWrong");
            }

            if (lowerTechnique=="homemade")
            {
                techniqueValueToSet = Homemade;
            }

            else if (lowerTechnique=="crispy")
            {
                techniqueValueToSet = Crispy;
            }

            else if (lowerTechnique=="chewy")
            {
                techniqueValueToSet = Chewy;
            }

            else
            {
                DoughException exc = new DoughException("typeWrong");
            }

            this.FlourTypeValue = flourValueToSet;
            this.BakingTechniqueValue = techniqueValueToSet;
        }

       
    }
}
