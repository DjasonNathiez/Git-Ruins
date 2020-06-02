using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class DoDamage :  MonoBehaviour
{
    private GameObject player;
    private Collider2D playerCollider;
    private Collider2D objectCollider;
    private PlayerDeath script;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerCollider = player.GetComponent<Collider2D>();
        objectCollider = gameObject.GetComponent<Collider2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (playerCollider.IsTouching(objectCollider))
        GameObject.FindWithTag("Player").SendMessage("Death");
        //gameObject.GetComponent<DoDamage>().enabled = false;    
        /*script = player.GetComponent<PlayerDeath>();
        script.enabled = false;*/
    }
    


}
