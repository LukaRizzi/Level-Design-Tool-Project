using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element_CameraObject : Element
{
    private CamController camController;

    private Transform prevObj;

    [Header("El nuevo objetivo para que siga la c�mara")]
    [SerializeField] private Transform objetoASeguir;

    private void Start()
    {
        //Guardar el controlador de c�mara para editarlo m�s c�modo
        camController = GameObject.FindGameObjectWithTag("MainCamera").transform.GetComponent<CamController>();
    }

    private new void Activate()
    {
        prevObj = camController.objetoASeguir; //Guardar el objeto previo por si �ste objeto es temporal
        camController.objetoASeguir = objetoASeguir; //Actualizar el objeto de la c�mara
    }

    private new void Deactivate()
    {
        if (camController.objetoASeguir == objetoASeguir)
        {
            camController.objetoASeguir = prevObj;
        }
    }
}