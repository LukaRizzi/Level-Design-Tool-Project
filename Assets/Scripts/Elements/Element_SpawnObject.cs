using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element_SpawnObject : Element
{
    [SerializeField] private GameObject objectToSpawn = null;
    [SerializeField] private Vector2 position = Vector2.zero;
    [Header("La posición se suma a la de éste objeto?")]
    [SerializeField] private bool relative = false;

    public new void Activate()
    {
        Vector3 _pos = relative? transform.position + (Vector3)position : position;

        Instantiate(objectToSpawn, _pos, Quaternion.identity);
    }
}