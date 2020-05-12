using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private Transform playerTransform;
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;

    public void Start()
    {
        playerTransform = GameObject.Find("Character").transform;
    }

    private void LateUpdate()
    {

        //suivis de la caméra sur le personnage
        Vector3 temp = transform.position;

        temp.x = playerTransform.position.x;
        temp.y = playerTransform.position.y;

        //clamp caméra
        transform.position = temp;
        float x = Mathf.Clamp(playerTransform.position.x, xMin, xMax);
        float y = Mathf.Clamp(playerTransform.position.y, yMin, yMax);
        transform.position = new Vector3(x, y, transform.position.z);
            
    }
}
