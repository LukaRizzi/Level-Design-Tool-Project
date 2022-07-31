using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    private Camera cam;

    [Header("El tamaño promedio es 24.")]
    public float tamañoDeCamara = 24;
    [Header("No mover cámara.")]
    public bool bloquearCamara = true;
    [Header("Seguir a un objeto a una velocidad")]
    public Transform objetoASeguir;
    [Header("0 es instantáneo.")]
    [Range(0,20)]
    public float velocidadDeCamara = 1;
    [Header("Debería apuntar hacia adelante la cámara?")]
    public Vector2 offsetDeCamara = Vector2.zero;

    private void Awake()
    {
        cam = GetComponent<Camera>();
    }

    private void FixedUpdate()
    {
        // ---- CAMBIAR TAMAÑO DE CÁMARA ----
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, tamañoDeCamara, .07f);

        //Si la cámara está bloqueada, no necesitamos hacer nada más
        if (bloquearCamara)
            return;

        // ---- MOVER CÁMARA ----

        float lerpSpeed = velocidadDeCamara == 0 ? 1 : velocidadDeCamara / 100; //Calcular la velocidad de la Cámara. Si la velocidad que pusiste es 0, que la velocidad sea instantánea.

        //Calcular la posición objetivo
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