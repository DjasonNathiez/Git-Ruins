using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    private GameObject player;
    private BoxCollider2D playerCollider;
    private CircleCollider2D activatorCollider;
    private Animator animator;
    bool activationInput;
    [Header("GameObjet associé")]
    [SerializeField] GameObject associatedObject1 = null;
    [SerializeField] GameObject associatedObject2 = null;
    [SerializeField] GameObject associatedObject3 = null;

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
        activatorCollider = gameObject.GetComponent<CircleCollider2D>();
        playerCollider = player.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Return was pressed");
            activationInput = true;
        }
        else
            activationInput = false;

        Activation();

    }

    private void Activation()
    {
        if (activationInput && playerCollider.IsTouching(activatorCollider))
        {
            if (associatedObject1 != null)
                associatedObject1.SetActive(true);
            if (associatedObject2 != null)
                associatedObject2.SetActive(true);
            if (associatedObject3 != null)
                associatedObject3.SetActive(true);

            Debug.Log("Activation");
            animator.SetBool("Activating", true);
            FindObjectOfType<SoundManager>().PlaySound("Activator");
        }

    }
}
