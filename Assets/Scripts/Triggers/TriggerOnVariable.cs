using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;

public class TriggerOnVariable : Trigger
{
    [SerializeField] private Condition[] conditions;

    private void Update()
    {
        triggered = CheckTriggered();
    }

    private bool CheckTriggered()
    {
        foreach (Condition condition in conditions)
        {
            if (!State(condition))
            {
                return false;
            }
        }
        return true;
    }

    public bool State(Condition _condition)
    {
        float _firstNumber = VariableManager.GetVariable(_condition.firstValue);
        float _secondNumber = VariableManager.GetVariable(_condition.secondValue);

        switch (_condition.comparison)
        {
            case Comparison.Equals:
                return _firstNumber == _secondNumber;
            case Comparison.Greater:
                return _firstNumber > _secondNumber;
            case Comparison.GreaterEqual:
                return _firstNumber >= _secondNumber;
            case Comparison.Smaller:
                return _firstNumber < _secondNumber;
            case Comparison.SmallerEqual:
                return _firstNumber <= _secondNumber;
        }
        Debug.Log("no deberías estar acá (triggeronvariable)");
        return false;
    }
}
