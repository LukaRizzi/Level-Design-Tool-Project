using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element_KillPlayer : Element
{
    [HideInInspector] public GameManager gm;
    [HideInInspector] public PlayerScript player;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
    }

    public new void Activate()
    {
        player.dead = true; //Matarlo
        player.transform.GetComponent<Rigidbody2D>().velocity = Vector2.zero; //Que no se pueda mover más jeje
        player.transform.GetComponent<Rigidbody2D>().isKinematic = true;
        gm.Invoke("RestartLevel", 1f); //Reiniciar en un segundo. Está bueno no reiniciar instantáneo para que el jugador tenga feedback visual de dónde murió y no sienta que fue repentino e injusto.
    }
}
