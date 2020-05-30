using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostCubes : MonoBehaviour
{
    Animator animator;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>(); 
    }

    private void OnEnable()
    {
        //CubeSpawn();
    }

    void CubeSpawn()
    {
        animator = gameObject.GetComponent<Animator>();
        animator.SetBool("Spawn", true);
        Debug.Log("poping");

    
    }

    void CubeDepop()
    {
        animator.SetBool("Depop", true);
        Debug.Log("Depoping");

    }

}
