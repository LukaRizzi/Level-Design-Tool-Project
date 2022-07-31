using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element_CameraSize : Element
{
    private CamController camController;
    private float prevSize;

    [SerializeField] private float nuevoTamaño = 24;

    private void Start()
    {
        //Guardar el controlador de cámara para editarlo más cómodo
        camController = GameObject.FindGameObjectWithTag("MainCamera").transform.GetComponent<CamController>();
    }

    public new void Activate()
    {
        prevSize = camController.tamañoDeCamara; //Guardar el tamaño previo por si éste cambio es temporal
        camController.tamañoDeCamara = nuevoTamaño; //Actualizar el tamaño de la cámara
    }

    public new void Deactivate()
    {
        camController.tamañoDeCamara = prevSize;
    }
}
