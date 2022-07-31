using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;

public class TriggerOr : Trigger
{
    [SerializeField] private Trigger[] triggers;
    [HideInInspector] public new bool triggered => CheckTriggered();

    private bool CheckTriggered()
    {
        foreach (Trigger trigger in triggers)
        {
            if (trigger.triggered)
            {
                return true;
            }
        }
        return false;
    }
}