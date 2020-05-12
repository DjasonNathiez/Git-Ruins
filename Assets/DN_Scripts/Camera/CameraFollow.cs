using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private Transform playerTransform;

    private GameObject CameraA;
    private GameObject CameraB;
    private GameObject CameraC;

    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;

    public void Start()
    {
        playerTransform = GameObject.Find("Character").transform;
        CameraA = GameObject.Find("Main Camera");
        CameraB = GameObject.Find("Camera Low");
        CameraC = GameObject.Find("Camera Large");
    }

    private void LateUpdate()
    {

        //suivis de la caméra sur le personnage
        Vector3 temp = transform.position;

        temp.x = playerTransform.position.x;
        temp.y = playerTransform.position.y;

        //clamp caméra
        transform.position = temp;

        transform.position = new Vector3(
            Mathf.Clamp(playerTransform.position.x, xMin, xMax),
            Mathf.Clamp(playerTransform.position.y, yMin, yMax),
            transform.position.z
            );
    }

    private void OnTriggerEnter2D(Collider2D collision) //camera switch MAIN > LOW > LARGE
    {
        if (collision.CompareTag("CameraLow"))
        {
            CameraA.SetActive(false);
            CameraB.SetActive(true);
            CameraC.SetActive(false);
        }
        else if (collision.CompareTag("CameraLarge"))
        {
            CameraA.SetActive(false);
            CameraB.SetActive(false);
            CameraC.SetActive(true);
        }
        else if (collision.CompareTag("MainCamera"))
        {
            CameraA.SetActive(true);
            CameraB.SetActive(false);
            CameraC.SetActive(false);
        }
    }

}
