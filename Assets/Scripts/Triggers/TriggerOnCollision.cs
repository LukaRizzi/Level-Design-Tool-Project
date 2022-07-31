using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerOnCollision : Trigger
{
    [SerializeField] private string tagToCheck = "Player";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag(tagToCheck))
        {
            triggered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag(tagToCheck))
        {
            triggered = false;
        }
    }
}
