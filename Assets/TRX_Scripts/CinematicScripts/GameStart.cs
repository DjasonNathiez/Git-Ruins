using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    [Header("Game Menu")]
    public GameObject eventSystem;
    public GameObject mainMenu;
    public GameObject character;

    private Rigidbody2D characterRigidbody;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnEnable()
    {
        eventSystem.SetActive(false);
        mainMenu.SetActive(false);
        //character.SetActive(true);
        characterRigidbody = character.GetComponent<Rigidbody2D>();
        animator = character.GetComponent<Animator>();
        StartCoroutine("Awakening");
    }

    IEnumerator Awakening()
    {
        animator.SetBool("Awakening", true);

        characterRigidbody.constraints = RigidbodyConstraints2D.FreezePosition;
        yield return new WaitForSeconds(9.0f);
        characterRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        Debug.Log("Awaken");
        StopCoroutine("Awakening");
    }
}
