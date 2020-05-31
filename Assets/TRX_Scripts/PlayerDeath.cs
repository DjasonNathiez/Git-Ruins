using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private GameObject respawnPoint;
    private GameObject currentPlayer;


    void Start()
    {
        respawnPoint = GameObject.FindWithTag("Respawn");
        currentPlayer = GameObject.FindWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Death()
    {
        //play Death animation
        respawnPoint.transform.position = new Vector3(respawnPoint.transform.position.x, respawnPoint.transform.position.y, 0);

        //Teleport the player GameObject to the respawn point location
        currentPlayer.transform.position = respawnPoint.transform.position;       
    }

}
