using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element_SubtractVariable : Element
{
    [SerializeField] private string variableName = "";
    [SerializeField] private string subtract;

    public new void Activate()
    {
        float _number1 = PlayerPrefs.HasKey(variableName) ? PlayerPrefs.GetFloat(variableName) : 0;
        float _number2 = VariableManager.GetVariable(subtract);

        PlayerPrefs.SetFloat(variableName, _number1 - _number2);
    }
}