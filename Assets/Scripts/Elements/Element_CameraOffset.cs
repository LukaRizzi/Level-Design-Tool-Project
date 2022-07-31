using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element_CameraOffset : Element
{
    private CamController camController;
    private Vector2 prevOffsetDeCamara;

    [SerializeField] private Vector2 offsetDeCamara = Vector2.zero;

    private void Start()
    {
        //Guardar el controlador de cámara para editarlo más cómodo
        camController = GameObject.FindGameObjectWithTag("MainCamera").transform.GetComponent<CamController>();
    }

    public new void Activate()
    {
        prevOffsetDeCamara = camController.offsetDeCamara; //Guardar el offset previo por si éste objeto es temporal
        camController.offsetDeCamara = offsetDeCamara; //Actualizar el offset de la cámara
    }

    public new void Deactivate()
    {
        camController.offsetDeCamara = prevOffsetDeCamara;
    }
}
