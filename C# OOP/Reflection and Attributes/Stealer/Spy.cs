using System;
using System.Linq;
using System.Text;
using System.Reflection;

public class Spy
{
    public string StealFieldInfo(string className, params string[] classFields)
    {
        Type type = Type.GetType(className);

        FieldInfo[] fields = type.GetFields(
        BindingFlags.Instance |
        BindingFlags.Public |
        BindingFlags.NonPublic |
        BindingFlags.Static);

        StringBuilder sb = new StringBuilder();

        Object classInstance = Activator.CreateInstance(type, new object[] { });

        sb.AppendLine($"Class under investigation: {className}");

        var filteredFields = fields
        .Where(f => classFields.Contains(f.Name))
        .ToList();

        foreach (FieldInfo field in filteredFields)
        {
            sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
        }

        return sb.ToString().TrimEnd();
    }
}