using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goutte : MonoBehaviour
{
    private Animator animator;
    private AudioSource splash;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        splash = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine("AutoDestruct");
    }

    IEnumerator AutoDestruct()
    {
        animator.SetBool("onHit", true);
        splash.Play(0);
        yield  return new WaitForSeconds(0.3f);
        Destroy(gameObject);

    }

}
