using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element_DestroyObject : Element
{
    [SerializeField] private bool thisObject = true;
    [Header("In case you want to destroy another object")]
    [SerializeField] private GameObject objectToDestroy = null;

    private void Start()
    {
        if (thisObject)
        {
            objectToDestroy = gameObject;
        }
    }

    public new void Activate()
    {
        Destroy(objectToDestroy, .0f);
    }
}