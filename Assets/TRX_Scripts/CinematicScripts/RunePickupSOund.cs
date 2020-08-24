using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunePickupSOund : MonoBehaviour
{
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Woom()
    {
        audioSource.Play();
    }
}
