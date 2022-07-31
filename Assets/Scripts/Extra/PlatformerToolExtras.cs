using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;

public enum Comparison
{
    Equals,
    Greater,
    GreaterEqual,
    Smaller,
    SmallerEqual
}

public enum Mode
{
    OnStart,
    Constant,
    OnChange,
}

[System.Serializable]
public struct Condition
{
    public string firstValue;
    public Comparison comparison;
    public string secondValue;
}

public static class VariableManager
{
    public static float GetVariable(string _string)
    {
        if (!float.TryParse(_string, NumberStyles.Any, CultureInfo.InvariantCulture, out float _value))
        {
            if (!PlayerPrefs.HasKey(_string))
            {
                return 0;
            }

            _value = PlayerPrefs.GetFloat(_string);
        }

        return _value;
    }
}