using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    private GameObject player;
    [SerializeField] public GameObject teleportPoint = null;
    private BoxCollider2D playerCollider;
    private Collider2D objectCollider;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerCollider = player.GetComponent<BoxCollider2D>();
        objectCollider = gameObject.GetComponent<Collider2D>();

        // Update is called once per frame
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Téléporteur Ready !");
        Portal();

    }

    void Portal()
    {
        //Teleport player to teleport point position
        teleportPoint.transform.position = new Vector3(teleportPoint.transform.position.x, teleportPoint.transform.position.y, 0);
        player.transform.position = teleportPoint.transform.position;
    }
}
