using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parralax : MonoBehaviour
{
    public CustomCharacterController cameraSwitch;

    public Transform[] backgrounds; //liste des backgrounds qui subissent la parallax
    private float[] parralaxScales;
    public float smooth; //toujours au dessus de 0

    private Transform cam;
    public Transform CameraLow;
    public Transform CameraLarge;
    public Transform CameraMain;

    private Vector3 previousCamMainPos; //position de la camera dans la frame précedente

    public void Awake()
    {
        cameraSwitch = FindObjectOfType<CustomCharacterController>();
        CameraLow = GameObject.FindGameObjectWithTag("CameraLow").transform;
        CameraLarge = GameObject.FindGameObjectWithTag("CameraLarge").transform;
        CameraMain = Camera.main.transform;

        CameraActive();
    }
    public void Start()
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

        CameraActive();

        for (int i = 0; i < backgrounds.Length; i++)
        {
             float parralax = (previousCamMainPos.x - cam.position.x) * parralaxScales[i];

             float backgroundTargetPosX = backgrounds[i].position.x + parralax;

             Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

             backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smooth * Time.deltaTime);
        }

        previousCamMainPos = cam.position;

    }


    public void CameraActive()
    {

        bool camLow = cameraSwitch.CameraLow;
        bool camLarge = cameraSwitch.CameraLarge;
        bool camMain = cameraSwitch.CameraMain;

        if (camLow == true)
        {
            cam = CameraLow;
        }

        if (camLarge == true)
        {
            cam = CameraLarge;
        }

        if (camMain == true)
        {
            cam = CameraMain;
        }
    }

}
