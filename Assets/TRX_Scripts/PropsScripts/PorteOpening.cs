using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorteOpening : MonoBehaviour
{

    GameObject porte;
    [SerializeField] string porteCible = null;
    Collider2D porteCollider;



    [Header("Cubes")]
    [SerializeField] GameObject cube1 = null;
    [SerializeField] GameObject cube2 = null;
    [SerializeField] GameObject cube3 = null;
    [SerializeField] GameObject cube4 = null;
    [SerializeField] GameObject cube5 = null;
    [SerializeField] GameObject cube6 = null;

    void Start()
    {
       
    }

    private void OnEnable()
    {
        porte = GameObject.Find(porteCible);
        Debug.Log(porteCible);
        porte.SendMessage("OpenDoor");

   
    }

    void OpenDoor()
    {
        //Suprrimer le collider de la porte
        porteCollider = GetComponentInChildren<BoxCollider2D>();
        Destroy(porteCollider);

        if (cube1 != null)
        {
            cube1.SendMessage("CubeDepop");
        }
        if (cube2 != null)
        {
            cube2.SendMessage("CubeDepop");
        }
        if (cube3 != null)
        {
            cube3.SendMessage("CubeDepop");
        }
        if (cube4 != null)
        {
            cube4.SendMessage("CubeDepop");
        }
        if (cube5 != null)
        {
            cube5.SendMessage("CubeDepop");
        }
        if (cube6 != null)
        {
            cube6.SendMessage("CubeDepop");
        }

    }


}
