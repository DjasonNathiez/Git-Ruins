using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorteOpening : MonoBehaviour
{
    public bool isVertical;
    public bool isHorizontal;

    GameObject porte;
    [SerializeField] string porteCible = null;
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
        //transform.Translate(new Vector3(0, 6f, 0));
        if(isVertical)
        transform.position = transform.position + new Vector3(0, 6f, 0);
        else if (isHorizontal)
        transform.position = transform.position + new Vector3(-4f, 0, 0);

    }


}
