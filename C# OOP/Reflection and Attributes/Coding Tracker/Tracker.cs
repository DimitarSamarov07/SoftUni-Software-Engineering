using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;


public class Tracker
{
    public void PrintMethodsByAuthor()
    {
        var type = typeof(StartUp);
        var methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public);

        foreach (var method in methods)
        {
            if (method.CustomAttributes.Any(n => n.AttributeType == typeof(AuthorAttribute)))
            {
                var attributes = method.GetCustomAttributes(false);
                foreach (AuthorAttribute attribute in attributes)
                {
                    Console.WriteLine("{0} is written by {1}", method.Name, attribute.Name);
                }
            }
        }
    }
}

