using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parralax : MonoBehaviour
{
    CameraSwitch cameraSwitch;

    public Transform[] backgrounds; //liste des backgrounds qui subissent la parallax
    private float[] parralaxScales;
    public float smooth; //toujours au dessus de 0

    public bool camLow;
    public bool camLarge;
    public bool camMain;

    private Transform cam;

    private Vector3 previousCamMainPos; //position de la camera dans la frame précedente

    private void Awake()
    {
        cam = Camera.main.transform;
    }
    private void Start()
    {
        
        //la position de la caméra main à la frame précédente
        previousCamMainPos = cam.position;

        //correspondance de la parralaxScales
        parralaxScales = new float[backgrounds.Length];

        for (int i = 0; i < backgrounds.Length; i++)
        {
            parralaxScales[i] = backgrounds[i].position.z * -1;
        }
    }

    public void Update()
    {

        for (int i = 0; i < backgrounds.Length; i++)
        {
             float parralax = (previousCamMainPos.x - cam.position.x) * parralaxScales[i];

             float backgroundTargetPosX = backgrounds[i].position.x + parralax;

             Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

             backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smooth * Time.deltaTime);
        }

        previousCamMainPos = cam.position;

    }

}
