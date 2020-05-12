using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    private GameObject player;
    public GameObject teleportPoint;
    private BoxCollider2D playerCollider;
    private Collider2D objectCollider;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerCollider = player.GetComponent<BoxCollider2D>();
        objectCollider = gameObject.GetComponent<Collider2D>();
        teleportPoint = GameObject.FindWithTag("");

        // Update is called once per frame
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Téléporteur Ready !");
        Portal();

    }

    void Portal()
    {
        //play Death animation
        teleportPoint.transform.position = new Vector3(teleportPoint.transform.position.x, teleportPoint.transform.position.y, 0);

        //Teleport the player GameObject to the respawn point location
        player.transform.position = teleportPoint.transform.position;
    }
}
