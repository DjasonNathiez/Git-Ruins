using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    public int index;
    public string LevelName;
    public Animator animator;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine("LevelLoad");
        }
    }

    IEnumerator LevelLoad()
    {
        animator.SetBool("isFading", true);
        yield return new WaitForSeconds(0.80f);
        SceneManager.LoadScene(index);
        Debug.Log("Level Switch");
    }

}
