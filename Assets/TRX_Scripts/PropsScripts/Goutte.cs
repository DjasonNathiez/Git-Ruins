using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goutte : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
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
        yield  return new WaitForSeconds(0.3f);
        Destroy(gameObject);

    }

}
