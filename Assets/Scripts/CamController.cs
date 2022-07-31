using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    private Camera cam;

    [Header("El tama�o promedio es 24.")]
    public float tama�oDeCamara = 24;
    [Header("No mover c�mara.")]
    public bool bloquearCamara = true;
    [Header("Seguir a un objeto a una velocidad")]
    public Transform objetoASeguir;
    [Header("0 es instant�neo.")]
    [Range(0,20)]
    public float velocidadDeCamara = 1;
    [Header("Deber�a apuntar hacia adelante la c�mara?")]
    public Vector2 offsetDeCamara = Vector2.zero;

    private void Awake()
    {
        cam = GetComponent<Camera>();
    }

    private void FixedUpdate()
    {
        // ---- CAMBIAR TAMA�O DE C�MARA ----
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, tama�oDeCamara, .07f);

        //Si la c�mara est� bloqueada, no necesitamos hacer nada m�s
        if (bloquearCamara)
            return;

        // ---- MOVER C�MARA ----

        float lerpSpeed = velocidadDeCamara == 0 ? 1 : velocidadDeCamara / 100; //Calcular la velocidad de la C�mara. Si la velocidad que pusiste es 0, que la velocidad sea instant�nea.

        //Calcular la posici�n objetivo
        Vector3 lerpPosition = new Vector3(
            objetoASeguir.position.x + offsetDeCamara.x,
            objetoASeguir.position.y + offsetDeCamara.y,
            transform.position.z);

        if (Vector3.Distance(transform.position, lerpPosition) > .1f)
        {
            transform.position = Vector3.Lerp(transform.position, lerpPosition, lerpSpeed); //Moverme
        }
    }
}