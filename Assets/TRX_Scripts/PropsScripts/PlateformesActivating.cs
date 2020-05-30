using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformesActivating : MonoBehaviour
{ 

    [Header("Cubes")]
    [SerializeField] GameObject cube1 = null;
    [SerializeField] GameObject cube2 = null;
    [SerializeField] GameObject cube3 = null;
    [SerializeField] GameObject cube4 = null;

    void Start()
    {

    }

    private void OnEnable()
    {
        ActivatePlatform();
    }

    void ActivatePlatform()
    {
        Debug.Log("Plateformes activées !");
        if (cube1 != null)
        {
            Debug.Log("Msg cube1");
            cube1.SendMessage("CubeSpawn");
        }
        if (cube2 != null)
        {
            Debug.Log("Msg cube2");
            cube2.SendMessage("CubeSpawn");
        }
        if (cube3 != null)
        {
            Debug.Log("Msg cube3");
            cube3.SendMessage("CubeSpawn");
        }
        if (cube4 != null)
        {
            Debug.Log("Msg cube4");
            cube4.SendMessage("CubeSpawn");
        }


        /*//transform.Translate(new Vector3(0, 6f, 0));
        if(isVertical)
        transform.position = transform.position + new Vector3(0, 6f, 0);
        else if (isHorizontal)
        transform.position = transform.position + new Vector3(-4f, 0, 0);
        */
    }
}
