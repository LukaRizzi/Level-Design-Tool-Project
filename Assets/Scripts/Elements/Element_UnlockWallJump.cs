using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element_UnlockWallJump : Element
{
    private PlayerScript player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform.GetComponent<PlayerScript>();
    }

    public new void Activate()
    {
        player.saltoDePared = true; //Desbloquear salto en pared
    }

    public new void Dectivate()
    {
        player.saltoDePared = true; //Desbloquear salto en pared
    }
}
