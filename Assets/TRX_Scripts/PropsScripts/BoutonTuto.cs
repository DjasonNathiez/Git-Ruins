using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoutonTuto : MonoBehaviour
{
    private Collider2D trigger;
    private Collider2D playerCollider;
    public Animator animator1;
    public Animator animator2;
    public GameObject boutonTuto1;
    public GameObject boutonTuto2;


    
    // Start is called before the first frame update
    void Start()
    {
        trigger = gameObject.GetComponent<Collider2D>();
        playerCollider = GameObject.FindWithTag("Player").GetComponent<Collider2D>();

    }

    private void OnTriggerEnter2D(Collider2D playerCollider)
    {
        if(boutonTuto1 != null) boutonTuto1.SetActive(true);
        if(boutonTuto2 != null) boutonTuto2.SetActive(true);

        //animator.SetBool("Activation", true);
    }

    private void OnTriggerExit2D(Collider2D playerCollider)
    {

        if(animator1 != null) animator1.SetBool("End", true);
        if(animator2 != null) animator2.SetBool("End", true);
        //boutonTuto.SetActive(false);

    }

    private void OnTriggerStay2D(Collider2D playerCollider)
    {
        if (animator1 != null) animator1.SetBool("Idle", true);
        if (animator2 != null) animator2.SetBool("Idle", true);

    }

}
