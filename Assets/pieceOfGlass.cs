using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pieceOfGlass : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.name == "BottomWall")
        {
            Destroy(gameObject);

        }
        if (col.name.Contains("hield"))
        {
            Debug.Log(col.tag);
            Destroy(gameObject);
            Destroy(col.gameObject);
        }

    }
    }
