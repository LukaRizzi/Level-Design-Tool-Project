using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerInvert : Trigger
{
    [SerializeField] private Trigger[] triggers;
    [HideInInspector] public new bool triggered => CheckTriggered();

    private bool CheckTriggered()
    {
        foreach (Trigger trigger in triggers)
        {
            if (trigger.triggered)
            {
                return false;
            }
        }
        return true;
    }
}
