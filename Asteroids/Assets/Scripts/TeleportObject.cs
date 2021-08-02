using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportObject : MonoBehaviour
{
    Vector2 ObjectPosition;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        ObjectPosition = transform.position;

        if (collider.gameObject.tag == "TeleportX")
        {
            transform.position = new Vector2(-ObjectPosition[0], ObjectPosition[1]);
        }
        if (collider.gameObject.tag == "TeleportY")
        {
            transform.position = new Vector2(ObjectPosition[0], -ObjectPosition[1]);
        }
    }
       
    }
