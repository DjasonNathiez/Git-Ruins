using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public float waitingTime;
    public int index;

    void Start()
    {
        StartCoroutine(BackToMenu());
    }


    IEnumerator BackToMenu()
    {
        yield return new WaitForSeconds(waitingTime);
        SceneManager.LoadScene(index);
    }

}
