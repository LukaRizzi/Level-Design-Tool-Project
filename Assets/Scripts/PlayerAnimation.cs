using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AnimacionDeJugador", menuName = "LukaEditor/Animación de jugador", order = 1)]
public class PlayerAnimation : ScriptableObject
{
    public Vector2 saltoEnPiso
        = new Vector2(.66f, 1.5f);
    public Vector2 saltoEnPared = new Vector2(1, 1);
    public Vector2 saltoEnAire = new Vector2(.83f, 1.2f);
    public Vector2 impactoCaida = new Vector2(1.5f, .66f);
    [Range(0.01f,.3f)]
    public float velocidadDeAnimacion = .1f;
}
