namespace ValidationAttributes.Attributes
{
    public class MyRequiredAttribute : MyValidationAttribute
    {
        public override bool IsValid(object obj)
        {
            bool result = false;

            if (obj != null)
            {
                result = true;
            }

            return result;
        }
    }
}
