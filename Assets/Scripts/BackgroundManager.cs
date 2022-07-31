using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField] private Background fondo;
    private SpriteRenderer sr;
    private Vector2 currentOffset = Vector2.zero;

    [Header("Textura del fondo.")]
    [SerializeField] private Sprite textura;
    [Header("Cu�ntas veces se repite la textura")]
    [SerializeField] private Vector2 tama�o = new Vector2(32, 18);
    [SerializeField] private Vector2 velocidad = new Vector2(0, 0);
    [SerializeField] private Vector2 velocidadDeParallax = new Vector2(0, 0);
    public Vector2 desplazamiento;
    [SerializeField] private Color color;
    private Background lastBG;

    private Camera cam;

    private void Start()
    {
        lastBG = fondo;
        sr = GetComponent<SpriteRenderer>();
        cam = Camera.main;
    }

    private void OnValidate() //Al cambiar un valor de �ste coso
    {
        if (cam == null)
        {
            cam = Camera.main;
        }
        if (fondo == null) //Si no hay un fondo, no hacer nada
            return;

        sr = GetComponent<SpriteRenderer>();

        if (sr.sharedMaterial == null) //Si el sprite no tiene material, no hacer nada
            return;

        if (lastBG == fondo) //Si cambiaste valores del fondo
        {
            fondo.textura = textura; //Actualizar el fondo
            fondo.tama�o = tama�o;
            fondo.velocidad = velocidad;
            fondo.color = color;
            fondo.velocidadDeParallax = velocidadDeParallax;
            fondo.desplazamiento = desplazamiento;
        }
        else //Si cambiaste el ID del fondo
        {
            lastBG = fondo; //Actualizar valores a los del fondo nuevo
            textura = fondo.textura;
            tama�o = fondo.tama�o;
            velocidad = fondo.velocidad;
            color = fondo.color;
            velocidadDeParallax = fondo.velocidadDeParallax;
            desplazamiento = fondo.desplazamiento;
        }

        //Actualizar visuales en base a la configuraci�n del fondo
        sr.sprite = fondo.textura;
        sr.sharedMaterial.SetTextureScale("_MainTex", fondo.tama�o);
        sr.sharedMaterial.color = fondo.color;

        //Calcular tama�o de fondo teniendo en cuenta la visi�n de la c�mara
        float _x = 85.3333333333f / (sr.sprite.rect.width / 100); //Ya s� que los par�ntesis no hacen falta, es para claridad interpret�ndolo si tengo q volver a toquetear este c�digo
        float _y = 48 / (sr.sprite.rect.height / 100);
        transform.localScale = new Vector3(_x, _y, 1);

        sr.sharedMaterial.SetTextureOffset("_MainTex", (cam.transform.position * velocidadDeParallax + desplazamiento));
    }

    private void Update()
    {
        if (velocidad != Vector2.zero || velocidadDeParallax != Vector2.zero) //Si el fondo tiene movimiento
        {
            currentOffset += velocidad * Time.deltaTime;

            sr.sharedMaterial.SetTextureOffset("_MainTex", (cam.transform.position * velocidadDeParallax * .001f + currentOffset + desplazamiento)); //Mover el fondo
        }

        //Calcular tama�o de fondo teniendo en cuenta la visi�n de la c�mara
        float _x = (((cam.orthographicSize * 2) / 9) * 16) / (sr.sprite.rect.width / 100); //Ya s� que los par�ntesis no hacen falta, es para claridad interpret�ndolo si tengo q volver a toquetear este c�digo
        float _y = (cam.orthographicSize * 2) / (sr.sprite.rect.height / 100);
        transform.localScale = new Vector3(_x, _y, 1);

        transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, transform.position.z);
    }
}