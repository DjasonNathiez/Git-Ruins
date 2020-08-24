using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Purification : MonoBehaviour
{
    private BoxCollider2D triggerCollider;
    private Collider2D playerCollider;
    private Animator corruAnimator;
    private Animator playerAnimator;
    private Rigidbody2D playerRigidbody;
    [Header("Cameras")]
    [SerializeField] GameObject camLarge = null;
    [SerializeField] GameObject camMiddle = null;


    // Start is called before the first frame update
    void Start()
    {
        triggerCollider = gameObject.GetComponent<BoxCollider2D>();
        playerCollider = GameObject.FindWithTag("Player").GetComponent<Collider2D>();
        playerRigidbody = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
        corruAnimator = GameObject.Find("Corruption Finale").GetComponent<Animator>();
        playerAnimator = GameObject.FindWithTag("Player").GetComponent<Animator>();

    }

    private void OnTriggerEnter2D(Collider2D playerCollider)
    {
        StartCoroutine("Timeline");
        Debug.Log("Timeline lancée !");
    }

    IEnumerator Timeline()
    {
        //Freeze le player
        playerRigidbody.constraints = RigidbodyConstraints2D.FreezePosition | RigidbodyConstraints2D.FreezeRotation;

        camMiddle.SetActive(true);
        camLarge.SetActive(false);
        yield return new WaitForSeconds(4.5f);

        //Lance l'animation de purification du Golem
        playerAnimator.SetBool("purification", true);
        yield return new WaitForSeconds(3.5f);

        //Lance l'animation de départ de la Corruption
        corruAnimator.SetBool("purification", true);
        yield return new WaitForSeconds(2.5f);

        //Unfreeze le player
        playerRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;

        //Detruire le Trigger & La Corruption
        GameObject.Find("Corruption Finale").SetActive(false);
        Destroy(gameObject);
        StopCoroutine("Timeline");


    }
}
