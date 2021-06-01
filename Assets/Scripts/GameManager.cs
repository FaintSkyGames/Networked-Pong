using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : NetworkManager
{
    public GameObject ball;

    public Transform player1Spawn;
    public Transform player2Spawn;
    public Transform ballSpawn;

    // When a player joins
    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        Transform start = numPlayers == 0 ? player1Spawn : player2Spawn; // Set the start point depending on the player
        GameObject player = Instantiate(playerPrefab, start.position, start.rotation);
        NetworkServer.AddPlayerForConnection(conn, player);

        if (numPlayers == 2)
        {
            ball = Instantiate(ball, ballSpawn.position, ballSpawn.rotation);
            NetworkServer.Spawn(ball); // Spawn when both clients are ready.
        }

    }

    public override void OnServerDisconnect(NetworkConnection conn)
    {
        // Destroy ball
        if (ball != null)
        {
            NetworkServer.Destroy(ball);
        }

        // Call base functionality (actually destroys the player)
        base.OnServerDisconnect(conn);
    }

    /*
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(ball, ballSpawn.position, ballSpawn.rotation);

        // Create bat and set position
        Paddle player1 = Instantiate(paddle, player1Spawn.position, player1Spawn.rotation) as Paddle;
        Paddle player2 = Instantiate(paddle, player2Spawn.position, player2Spawn.rotation) as Paddle;

        // Enable the correct controls
        player1.Init(true);
        player2.Init(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    */
}
