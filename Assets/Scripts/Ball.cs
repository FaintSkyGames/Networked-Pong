using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : NetworkBehaviour
{
    public float speed = 1;
    public Rigidbody2D rb2D;
    public GameObject ballSpawn;
    Vector2 direction;

    // Start is called before the first frame update
    public override void OnStartServer()
    {
        base.OnStartServer();

        ballSpawn = GameObject.Find("BallSpawn"); // Finds GameObject with the name BallSpawn
        direction = Vector2.one.normalized;
    }

    private void FixedUpdate()
    {
        rb2D.velocity = direction * speed;
    }

    // Is called on collision only on server side
    [ServerCallback]
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            direction.y = -direction.y;
        }
        else if (collision.gameObject.CompareTag("Paddle"))
        {
            direction.x = -direction.x;
        }
        else if (collision.gameObject.CompareTag("Death"))
        {
            direction.y = -direction.y;
            //transform.position = ballSpawn.transform.position;
        }
    }
}
