using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    private GameObject player;
    private BoxCollider2D playerCollider;
    private CircleCollider2D activatorCollider;
    bool activationInput;
    [Header("GameObjet associé")]
    [SerializeField] GameObject associatedObject1 = null;
    [SerializeField] GameObject associatedObject2 = null;
    [SerializeField] GameObject associatedObject3 = null;

    private void Start()
    {
        player = GameObject.Find("Character");
        activatorCollider = gameObject.GetComponent<CircleCollider2D>();
        playerCollider = player.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            activationInput = true;
        else
            activationInput = false;
        
    }

    private void FixedUpdate()
    {
        Activation();
    }

    private void Activation()
    {
        if (activationInput && playerCollider.IsTouching(activatorCollider))
        {
            associatedObject1.SetActive(true);
            associatedObject2.SetActive(true);
            associatedObject3.SetActive(true);

            Debug.Log("Activation");
        }
    }
}
