using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class AssembleRune : MonoBehaviour
{
    private BoxCollider2D triggerCollider;
    private Collider2D playerCollider;
    private Rigidbody2D playerRigidbody;

    private Animator runeUniteAnimator;
    private Animator playerAnimator;
    public GameObject runeParticle;

    public GameObject templeFX1;
    public GameObject templeFX2;
    public GameObject templeFX3;
    public GameObject templeFX4;
    public GameObject templeFX5;


    // Start is called before the first frame update
    void Start()
    {
        triggerCollider = gameObject.GetComponent<BoxCollider2D>();
        playerCollider = GameObject.FindWithTag("Player").GetComponent<Collider2D>();
        playerRigidbody = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
        runeUniteAnimator = GameObject.Find("RunesUnite").GetComponent<Animator>();
        playerAnimator = GameObject.FindWithTag("Player").GetComponent<Animator>();

        //playerAnimator.SetBool("Apparition", true);
    }

    private void OnTriggerEnter2D(Collider2D playerCollider)
    {
        StartCoroutine("Timeline");
        Debug.Log("Timeline lancée !");
    }



    IEnumerator Timeline()
    {
        //Téléportation dans la scène
        yield return new WaitForSeconds(2.5f);

        //Apparition de la Rune + Fusion de la Rune
        runeParticle.SetActive(true);
        yield return new WaitForSeconds(4.5f);
        runeUniteAnimator.SetBool("Reunite", true);
        runeParticle.SetActive(false);
        //Insérer le Flash
        Debug.Log("Réuni");
        yield return new WaitForSeconds(4.5f);

        SceneManager.LoadScene(0);

    }


}
