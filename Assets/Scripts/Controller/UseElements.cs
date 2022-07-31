using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseElements : MonoBehaviour
{
    [SerializeField] private Mode mode = Mode.OnChange;
    [SerializeField] private bool triggerDeactivate;
    [SerializeField] private Trigger[] triggers;
    [SerializeField] private Element[] efects;

    private bool prevTriggered = false;

    private void Start()
    {
        bool _triggered = true;
        foreach(Trigger trigger in triggers)
        {
            if (!trigger.triggered)
            {
                _triggered = false;
            }
        }

        if (mode == Mode.OnStart)
        {
            if (_triggered)
            {
                Use();
            }
            else
            {
                if (triggerDeactivate)
                {
                    UseDeactivate();
                }
            }
        }
    }

    private void Update()
    {
        bool _triggered = true;
        foreach (Trigger trigger in triggers)
        {
            if (!trigger.triggered)
            {
                _triggered = false;
            }
        }

        if ((mode == Mode.Constant && _triggered) ||
            (mode == Mode.OnChange && _triggered && !prevTriggered))
        {
            Use();
        }

        if (triggerDeactivate)
        {
            if ((mode == Mode.Constant || mode == Mode.OnChange) &&
            (!_triggered && prevTriggered))
            {
                UseDeactivate();
            }
        }

        prevTriggered = _triggered;
    }

    private void Use()
    {
        foreach (Element mb in efects)
        {
            if (mb == null)
                continue;
            mb.Invoke("Activate", .0f);
        }
    }

    private void UseDeactivate()
    {
        foreach (Element mb in efects)
        {
            if (mb == null)
                continue;
            mb.Invoke("Deactivate", .0f);
        }
    }
}
