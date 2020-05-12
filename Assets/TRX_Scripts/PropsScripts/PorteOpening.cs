using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorteOpening : MonoBehaviour
{
    GameObject parent;
    [SerializeField] string porteCible;
    void Start()
    {
        
    }

    private void OnEnable()
    {
        parent = GameObject.Find(porteCible);
        parent.SendMessage("OpenDoor");
   
    }

    void OpenDoor()
    {
        //transform.Translate(new Vector3(0, 6f, 0));
        transform.position = transform.position + new Vector3(0, 6f, 0);
    }


}
