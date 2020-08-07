using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    [Header("Game Menu")]
    public GameObject eventSystem;
    public GameObject mainMenu;
    public GameObject character;
    private bool coroutineIsOn = false;
    private IEnumerator coroutine;

    private Rigidbody2D characterRigidbody;
    private Animator animator;

    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        characterRigidbody = character.GetComponent<Rigidbody2D>();
        //characterRigidbody.constraints = RigidbodyConstraints2D.FreezePosition;
    }

    // Update is called once per frame
    private void OnEnable()
    {
        eventSystem.SetActive(false);
        mainMenu.SetActive(false);
        //character.SetActive(true);
        animator = character.GetComponent<Animator>();
        //coroutine = Awakening();
        Debug.Log("Fin de la boucle");
    }

    public void Update()
    {
        if(coroutineIsOn == false)
            StartCoroutine(Awakening());
    }

    public IEnumerator Awakening()
    {
        coroutineIsOn = true;
        animator.SetBool("Awakening", true);
        characterRigidbody.constraints = RigidbodyConstraints2D.FreezePosition;
        Debug.Log("freeze");
        yield return new WaitForSeconds(9.0f);
        characterRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        character.GetComponent<CustomCharacterController>().enabled = true;
        StopCoroutine("Awakening");
    }
}
