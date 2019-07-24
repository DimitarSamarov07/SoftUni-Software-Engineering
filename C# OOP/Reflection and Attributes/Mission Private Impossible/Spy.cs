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

    public string AnalyzeAcessModifiers(string className)
    {
        Type classType = Type.GetType(className);
        StringBuilder sb = new StringBuilder();
        FieldInfo[] publicFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
        MethodInfo[] publicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
        MethodInfo[] nonPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        foreach (FieldInfo publicField in publicFields)
        {
            sb.AppendLine($"{publicField.Name} must be private!");
        }
        foreach (var publicMethod in nonPublicMethods.Where(m => m.Name.StartsWith("get")))
        {
            sb.AppendLine($"{publicMethod.Name} have to be public!");
        }
        foreach (var privateMethod in publicMethods.Where(m => m.Name.StartsWith("set")))
        {
            sb.AppendLine($"{privateMethod.Name} have to be private!");
        }

        return sb.ToString().Trim();
    }

    public string RevealPrivateMethods(string className)
    {
        Type classType = Type.GetType(className);
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"All Private Methods of Class: {className}");
        sb.AppendLine($"Base Class: {classType.BaseType.Name}");
        MethodInfo[] privateMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        foreach (var privateMethod in privateMethods)
        {
            sb.AppendLine(privateMethod.Name);
        }

        return sb.ToString().Trim();
    }
}