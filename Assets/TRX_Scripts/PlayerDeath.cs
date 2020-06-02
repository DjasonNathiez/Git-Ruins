using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private GameObject respawnPoint;
    private GameObject currentPlayer;
    private Animator animator;


    void Start()
    {
        respawnPoint = GameObject.FindWithTag("Respawn");
        currentPlayer = GameObject.FindWithTag("Player");
        animator = gameObject.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Death()
    {
        //play Death animation
        animator.SetBool("death", true);
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition | RigidbodyConstraints2D.FreezeRotation;
        FindObjectOfType<SoundManager>().PlaySound("Player Death");

        yield return new WaitForSeconds(0.5f);

        respawnPoint.transform.position = new Vector3(respawnPoint.transform.position.x, respawnPoint.transform.position.y, 0);
        //Teleport the player GameObject to the respawn point location
        currentPlayer.transform.position = respawnPoint.transform.position;
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

    }

}
