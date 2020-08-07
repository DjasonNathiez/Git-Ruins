using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] float parallaxMultiplier = 0.0f;

    private Transform cameraTransform;

    private Vector3 startCameraPos;
    private Vector3 startPos;

    void Start()
    {
        cameraTransform = Camera.main.transform;
        startCameraPos = cameraTransform.position;
        startPos = transform.position;
    }


    private void LateUpdate()
    {
        var position = startPos;
        position.x += parallaxMultiplier * (cameraTransform.position.x - startCameraPos.x);
       
        transform.position = position;
    }

}

