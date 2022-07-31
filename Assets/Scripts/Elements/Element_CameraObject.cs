using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element_CameraObject : Element
{
    private CamController camController;

    private Transform prevObj;

    [Header("El nuevo objetivo para que siga la cámara")]
    [SerializeField] private Transform objetoASeguir;

    private void Start()
    {
        //Guardar el controlador de cámara para editarlo más cómodo
        camController = GameObject.FindGameObjectWithTag("MainCamera").transform.GetComponent<CamController>();
    }

    private new void Activate()
    {
        prevObj = camController.objetoASeguir; //Guardar el objeto previo por si éste objeto es temporal
        camController.objetoASeguir = objetoASeguir; //Actualizar el objeto de la cámara
    }

    private new void Deactivate()
    {
        if (camController.objetoASeguir == objetoASeguir)
        {
            camController.objetoASeguir = prevObj;
        }
    }
}