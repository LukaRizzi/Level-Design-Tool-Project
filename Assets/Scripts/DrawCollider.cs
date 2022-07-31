using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class DrawCollider : MonoBehaviour
{
    private BoxCollider2D coll;
    [SerializeField] private Color color = new Color(Color.red.r, Color.red.g, Color.red.b, .2f);

    private void Awake()
    {
        //Guardar el controlador de cámara para mostrar el rango en el editor
        coll = GetComponent<BoxCollider2D>();
    }

    void OnDrawGizmosSelected()
    {

#if UNITY_EDITOR
        Gizmos.color = color;

        //Draw the suspension
        Gizmos.DrawCube(transform.position, coll.size * transform.localScale);

        Gizmos.color = Color.white;
#endif
    }
}
