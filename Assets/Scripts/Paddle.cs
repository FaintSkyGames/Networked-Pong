using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : NetworkBehaviour
{
    public float speed = 20;
    public Rigidbody2D rb2D;

    string input;

    /*
    bool isLeft; // Used to determine which player

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    */

    // Using fixed update due to using a rigidbody
    void FixedUpdate()
    {
        if (isLocalPlayer)
        {
            float verticalMove = Input.GetAxis("PaddleLeft");
            Vector2 movement = new Vector2(0, verticalMove);

            rb2D.velocity = movement * speed * Time.fixedDeltaTime;
        }        
    }

    /*
    // Sets the controlls to the correct inputs
    public void Init(bool isLeftPaddle)
    {
        if (isLeftPaddle)
        {
            input = "PaddleLeft";
        }
        else
        {
            input = "PaddleRight";
        }
    }
    */
}
