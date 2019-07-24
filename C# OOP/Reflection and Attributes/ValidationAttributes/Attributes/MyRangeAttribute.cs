using System;

namespace ValidationAttributes.Attributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private readonly int minValue;
        private readonly int maxValue;

        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public override bool IsValid(object obj)
        {
            bool result = true;

            int value = Convert.ToInt32(obj);

            if (value < this.minValue || value > this.maxValue)
            {
                result = false;
            }

            return result;
        }
    }
}
