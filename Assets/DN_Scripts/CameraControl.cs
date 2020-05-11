using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraControl : MonoBehaviour
{
    GameObject CameraShort;
    GameObject CameraLarge;

    private void Awake()
    {
        CameraShort = GameObject.Find("CM ShortFOV");
        CameraLarge = GameObject.Find("CM LargeFOV");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("CameraEventShort"))
        {
            CameraShort.SetActive(true);
            CameraLarge.SetActive(false);
            Debug.Log("Short");
        }

        if (collision.CompareTag("CameraEventLarge"))
        {
            CameraShort.SetActive(false);
            CameraLarge.SetActive(true);
            Debug.Log("Large");
        }
    }

}
