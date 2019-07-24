using System;
using System.Linq;
using System.Reflection;

using ValidationAttributes.Attributes;

namespace ValidationAttributes.Validators
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            bool result = true;

            PropertyInfo[] propertyInfos = obj
                .GetType()
                .GetProperties();

            foreach (PropertyInfo property in propertyInfos)
            {
                var attributes = property
                    .GetCustomAttributes<MyValidationAttribute>(false)
                    .ToList();

                foreach (MyValidationAttribute attribute in attributes)
                {
                    Object propertyValue = property.GetValue(obj);

                    if (!attribute.IsValid(propertyValue))
                    {
                        result = false;
                    }
                }
            }

            return result;
        }
    }
}
