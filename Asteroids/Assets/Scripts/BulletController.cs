using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    
    public float speed;
    private Vector2 direction = new Vector2(1,0);
    private void FixedUpdate()
    {
        MoveBullet();
    }

    //если пуля попадёт в телепорт или в астероид
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "TeleportX" || collider.gameObject.tag == "TeleportY" || collider.gameObject.tag == "Asteroid")
        {
            gameObject.SetActive(false);
        }
    }
    private void MoveBullet()
    {
        transform.Translate(direction * speed);
    }
}
