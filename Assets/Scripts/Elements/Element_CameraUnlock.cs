using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element_CameraUnlock : Element
{
    private CamController camController;

    private void Start()
    {
        //Guardar el controlador de cámara para editarlo más cómodo
        camController = GameObject.FindGameObjectWithTag("MainCamera").transform.GetComponent<CamController>();
    }

    public new void Activate()
    {
        camController.bloquearCamara = false; //Desbloquear cámara
    }

    public new void Deactivate()
    {
        camController.bloquearCamara = true;
    }
}
