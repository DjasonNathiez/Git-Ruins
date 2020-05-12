using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    private CustomCharacterController customCharacterController;

    Vector4 cameraInitialPosition;
    public float shakeMagnitude = 0.05f;
    public float shakeTime = 0.05f;
    public Camera mainCamera;

    public bool IsGrounded;
    public void Start()
    {

    }

    // Update is called once per frame
   public void Update()
    {
        bool IsGrounded = GetComponent<CustomCharacterController>().isGrounded;

        if (IsGrounded == true)
        {
            ShakeIt();
            Debug.Log("ground");
        }
    }

    public void ShakeIt()
    {
        cameraInitialPosition = mainCamera.transform.position;
        InvokeRepeating("StartCameraShaking", 0f, 0.005f);
        Invoke("StopCameraShaking", shakeTime);
    }

    void StartCameraShaking()
    {
        float cameraShakingOffsetX = Random.value * shakeMagnitude * 2 - shakeMagnitude;
        float cameraShakingOffsetY = Random.value * shakeMagnitude * 2 - shakeMagnitude;
        Vector3 cameraIntermadiatePosition = mainCamera.transform.position;
        cameraIntermadiatePosition.x += cameraShakingOffsetX;
        cameraIntermadiatePosition.y += cameraShakingOffsetY;
        mainCamera.transform.position = cameraIntermadiatePosition;
    }

    void StopCameraShaking()
    {
        CancelInvoke("StartCameraShaking");
        mainCamera.transform.position = cameraInitialPosition;
        IsGrounded = false;
    }
}
