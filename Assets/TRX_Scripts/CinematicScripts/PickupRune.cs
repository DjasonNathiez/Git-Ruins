using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickupRune : MonoBehaviour
{
    private BoxCollider2D triggerCollider;
    private Collider2D playerCollider;
    private Animator runeAnimator;
    private Animator playerAnimator;
    private Rigidbody2D playerRigidbody;
    public GameObject runeParticle;

    
    // Start is called before the first frame update
    void Start()
    {
        triggerCollider = gameObject.GetComponent<BoxCollider2D>();
        playerCollider = GameObject.FindWithTag("Player").GetComponent<Collider2D>();
        playerRigidbody = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
        runeAnimator = GameObject.Find("Rune").GetComponent<Animator>();
        playerAnimator = GameObject.FindWithTag("Player").GetComponent<Animator>();


    }

    private void OnTriggerEnter2D(Collider2D playerCollider)
    {
        StartCoroutine("Timeline");
        Debug.Log("Timeline lancée !");
    }

    IEnumerator Timeline()
    {

        //Lancer l'animation de Twitch de la Rune
        runeAnimator.SetBool("Pickup", true);
        runeParticle.SetActive(true);
        //Freeze le player
        playerRigidbody.constraints = RigidbodyConstraints2D.FreezePosition;
        yield return new WaitForSeconds(3.5f);

        //Enlève le ParticleSystem + Animation de Disparition
        runeParticle.SetActive(false);
        runeAnimator.SetBool("Disparition", true);
        playerAnimator.SetBool("Disappear", true);
        yield return new WaitForSeconds(1.5f);

        //Lancer l'anim de Disparition du Golem
        playerAnimator.SetBool("Disappear", true);
        yield return new WaitForSeconds(1.0f);


        //Flash + Changement de scène (arrivée dans le temple final)
        SceneManager.LoadScene(9);


    }
}
