using System.Reflection;

namespace Helium.Controls.XValueButton.Utilities;

public static class HeXValueTypeExtension {
    public static double[] GetExp(this Enum value) {
        ExpAttribute[]? attributes = GetAttributes<ExpAttribute>(value);
        
        if (attributes == null || attributes.Length == 0) return [];
        return attributes[0].Exp;
    }
    
    public static string[] GetUnits(this Enum value) {
        UnitsAttribute[]? attributes = GetAttributes<UnitsAttribute>(value);
        
        if (attributes == null || attributes.Length == 0) return [];
        return attributes[0].Units;
    }
    
    public static string GetDefaultUnit(this Enum value) {
        DefaultUnitAttribute[]? attributes = GetAttributes<DefaultUnitAttribute>(value);
        
        if (attributes == null || attributes.Length == 0) return string.Empty;
        return attributes[0].DefaultUnit;
    }
    
    private static T[]? GetAttributes<T>(Enum value) where T : class {
        Type type = value.GetType();

        FieldInfo? fieldInfo = type.GetField(value.ToString());
        if (fieldInfo == null) return null;

        T[] attributes = (T[])fieldInfo.GetCustomAttributes(typeof(T), false);

        return attributes;
    }
}

public class ExpAttribute(params double[] values) : Attribute {
    public double[] Exp { get; } = values;
}

public class UnitsAttribute(params string[] values) : Attribute {
    public string[] Units { get; } = values;
}

public class DefaultUnitAttribute(string value) : Attribute {
    public string DefaultUnit { get; } = value;
}
