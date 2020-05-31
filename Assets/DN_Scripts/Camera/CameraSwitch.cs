using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    private GameObject cameraLow;
    private GameObject cameraLarge;
    private GameObject cameraMain;

    public bool CameraLow;
    public bool CameraLarge;
    public bool CameraMain;

    private void Awake()
    {
        cameraLow = GameObject.Find("Camera_Low");
        cameraLarge = GameObject.Find("Camera_Large");
        cameraMain = GameObject.Find("Main Camera");
    }

    private void Start()
    {
        if(CameraMain == true)
        {
            cameraMain.SetActive(true);
            cameraLow.SetActive(false);
            cameraLarge.SetActive(false);

            CameraMain = true;
            CameraLarge = false;
            CameraLow = false;
            
        }

        if (CameraLow == true)
        {
            cameraMain.SetActive(false);
            cameraLow.SetActive(true);
            cameraLarge.SetActive(false);

            CameraMain = false;
            CameraLarge = false;
            CameraLow = true;

        }

        if (CameraLarge == true)
        {
            cameraMain.SetActive(false);
            cameraLow.SetActive(false);
            cameraLarge.SetActive(true);

            CameraMain = false;
            CameraLarge = true;
            CameraLow = false;

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("CameraLow"))
        {
            Debug.Log("camlow find");
            cameraMain.SetActive(false);
            cameraLow.SetActive(true);
            cameraLarge.SetActive(false);

        }

        if (collision.CompareTag("CameraLarge"))
        {
            Debug.Log("camlarge find");
            cameraMain.SetActive(false);
            cameraLow.SetActive(false);
            cameraLarge.SetActive(true);

        }

        if (collision.CompareTag("MainCamera"))
        {
            Debug.Log("cammain find");
            cameraMain.SetActive(true);
            cameraLow.SetActive(false);
            cameraLarge.SetActive(false);

        }
    }
}
