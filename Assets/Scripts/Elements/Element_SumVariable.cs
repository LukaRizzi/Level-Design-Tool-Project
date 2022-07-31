using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element_SumVariable : Element
{
    [SerializeField] private string variableName = "";
    [SerializeField] private string sum;

    public new void Activate()
    {
        float _number1 = PlayerPrefs.HasKey(variableName) ? PlayerPrefs.GetFloat(variableName) : 0;
        float _number2 = VariableManager.GetVariable(sum);

        PlayerPrefs.SetFloat(variableName, _number1 + _number2);
    }
}