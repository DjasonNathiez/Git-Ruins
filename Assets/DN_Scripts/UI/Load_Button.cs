using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load_Button : MonoBehaviour
{
    public GameObject gameStart;
    public GameObject Settings;
    public GameObject character;
    private Rigidbody2D characterRigidbody;

    private void Awake()
    {
        characterRigidbody = character.GetComponent<Rigidbody2D>();
        characterRigidbody.constraints = RigidbodyConstraints2D.FreezePosition;
    }

    public void ButtonStart()
    {
        //SceneManager.LoadScene(1);
        gameStart.SetActive(true);
        characterRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;

    }

    public void ButtonQuit()
    {
        Application.Quit();
    }

    public void ButtonSetting()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Settings.SetActive(true);

        }

        if (Input.GetButtonDown("Cancel"))
        {
            Settings.SetActive(false);
        }
    }
}
