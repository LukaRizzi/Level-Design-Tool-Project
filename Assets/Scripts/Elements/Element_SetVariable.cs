using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;

public class Element_SetVariable : Element
{
    [SerializeField] private string variableName = "";
    [SerializeField] private string newValue;

    public new void Activate()
    {
        PlayerPrefs.SetFloat(variableName, VariableManager.GetVariable(newValue));
    }
}