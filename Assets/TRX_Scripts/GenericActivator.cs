using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericActivator : MonoBehaviour
{
    [SerializeField] GameObject associatedCam = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        associatedCam.SetActive(true);
    }
}
