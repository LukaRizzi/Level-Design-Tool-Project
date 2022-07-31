using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element_CameraSize : Element
{
    private CamController camController;
    private float prevSize;

    [SerializeField] private float nuevoTama�o = 24;

    private void Start()
    {
        //Guardar el controlador de c�mara para editarlo m�s c�modo
        camController = GameObject.FindGameObjectWithTag("MainCamera").transform.GetComponent<CamController>();
    }

    public new void Activate()
    {
        prevSize = camController.tama�oDeCamara; //Guardar el tama�o previo por si �ste cambio es temporal
        camController.tama�oDeCamara = nuevoTama�o; //Actualizar el tama�o de la c�mara
    }

    public new void Deactivate()
    {
        camController.tama�oDeCamara = prevSize;
    }
}
