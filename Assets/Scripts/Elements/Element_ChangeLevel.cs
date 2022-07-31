using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element_ChangeLevel : Element
{
    private GameManager gm;
    public string GoToLevel;
    private PlayerScript player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

   void Won(){gm.GoToLevel(GoToLevel);}

    public new void Activate()
    {
        player.dead = true; //Matarlo
        player.transform.GetComponent<Rigidbody2D>().velocity = Vector2.zero; //Que no se pueda mover más jeje
        player.transform.GetComponent<Rigidbody2D>().isKinematic = true;
        Invoke("Won", 1f);
    }
}