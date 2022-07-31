using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Background", menuName = "LukaEditor/Fondo", order = 1)]
public class Background : ScriptableObject
{
    public Sprite textura;
    public Vector2 desplazamiento = new Vector2(0, 0);
    public Vector2 tamaño = new Vector2(32, 18);
    public Vector2 velocidad = Vector2.zero;
    public Vector2 velocidadDeParallax = Vector2.zero;
    public Color color = Color.white;
}