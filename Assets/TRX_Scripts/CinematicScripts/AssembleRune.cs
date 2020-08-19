using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class AssembleRune : MonoBehaviour
{

    private BoxCollider2D triggerCollider;
    private Collider2D playerCollider;
    private Rigidbody2D playerRigidbody;
    private Animator playerAnimator;


    [SerializeField, Header("Camera Shake")]
    private GameObject mainCamera;
    Vector4 cameraInitialPosition;
    public float shakeMagnitude = 0.05f;
    public float shakeTime = 0.05f;
    bool isShaking = false;


    [Header("FXRune")]
    private Animator runeUniteAnimator;
    public GameObject runeParticle;
    public GameObject flash;

    [Header("FX Temple")]
    public GameObject templeFX;

    [Header("Corruption")]
    public GameObject corruption1;
    public GameObject corruption2;
    public GameObject corruption3;
    public GameObject corruption4;
    public GameObject corruption5;
    public GameObject corruption6;
    public GameObject corruption7;
    public GameObject corruption8;
    public GameObject corruption9;
    public GameObject corruption10;
    public GameObject corruption11;
    public GameObject corruption12;
    public GameObject corruption13;
    public GameObject corruption14;
    public GameObject corruption15;
    public GameObject corruption16;
    public GameObject corruption17;
    public GameObject corruption18;
    public GameObject corruption19;
    public GameObject corruption20;
    public GameObject corruption21;
    public GameObject corruption22;
    public GameObject corruption23;
    public GameObject corruption24;
    public GameObject corruption25;
    public GameObject corruption26;
    public GameObject corruption27;
    public GameObject corruption28;
    public GameObject corruption29;
    public GameObject corruption30;
    public GameObject corruption31;

    [Header("Rivière Uruz")]
    public GameObject circuitUruz;
    public Animator riviereUruz;
    public Animator templeCorru;


    // Start is called before the first frame update
    void Start()
    {

        triggerCollider = gameObject.GetComponent<BoxCollider2D>();
        playerCollider = GameObject.FindWithTag("Player").GetComponent<Collider2D>();
        playerRigidbody = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
        runeUniteAnimator = GameObject.Find("RunesUnite").GetComponent<Animator>();
        playerAnimator = GameObject.FindWithTag("Player").GetComponent<Animator>();


        //playerAnimator.SetBool("Apparition", true);
    }
    private void Update()
    {
        if (isShaking == true)
        {
            ShakeIt();
        }

    }

    private void OnTriggerEnter2D(Collider2D playerCollider)
    {
        StartCoroutine("Timeline");
        Debug.Log("Timeline lancée !");
    }



    IEnumerator Timeline()
    {
        //Téléportation dans la scène

        yield return new WaitForSeconds(0.5f);
        playerRigidbody.constraints = RigidbodyConstraints2D.FreezePosition;
        yield return new WaitForSeconds(1.5f);

        //Apparition de la Rune + Fusion de la Rune
        runeParticle.SetActive(true);
        isShaking = true;
        yield return new WaitForSeconds(2.5f);
        shakeMagnitude = 0.12f;
        yield return new WaitForSeconds(2.5f);
        isShaking = false;
        runeUniteAnimator.SetBool("Reunite", true);
        yield return new WaitForSeconds(1.2f);

        //FLASH + Disparition de la Corruption
        runeParticle.SetActive(false);
        flash.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        DisparitionCorruption();
        yield return new WaitForSeconds(1.5f);

        //Circuit Uruz
        circuitUruz.SetActive(true);
        flash.SetActive(false);

        //Rivière Uruz Start 
        yield return new WaitForSeconds(4.0f);
        riviereUruz.SetBool("RiviereStarting", true);
        //Boules d'énergie du Temple + Corruption Temple qui part
        //circuitUruz.SetActive(false);
        yield return new WaitForSeconds(3.0f);
        templeCorru.enabled = true;
        templeFX.SetActive(true);

        //Rivière Uruz Idle
        riviereUruz.SetBool("RiviereIdle", true);
        yield return new WaitForSeconds(15.0f);


        SceneManager.LoadScene(11);

    }

    public void ShakeIt()
    {

        cameraInitialPosition = mainCamera.transform.position;
        InvokeRepeating("StartCameraShaking", 0f, 0.005f);
        Invoke("StopCameraShaking", shakeTime);
    }

    public void StartCameraShaking()
    {
        float cameraShakingOffsetX = Random.value * shakeMagnitude * 2 - shakeMagnitude;
        float cameraShakingOffsetY = Random.value * shakeMagnitude * 2 - shakeMagnitude;
        Vector3 cameraIntermadiatePosition = mainCamera.transform.position;
        cameraIntermadiatePosition.x += cameraShakingOffsetX;
        cameraIntermadiatePosition.y += cameraShakingOffsetY;
        mainCamera.transform.position = cameraIntermadiatePosition;

    }

    public void StopCameraShaking()
    {
        CancelInvoke("StartCameraShaking");
        mainCamera.transform.position = cameraInitialPosition;
        //isGrounded = false;
    }

    private void DisparitionCorruption()
    {
        corruption1.SetActive(false);
        corruption2.SetActive(false);
        corruption3.SetActive(false);
        corruption4.SetActive(false);
        corruption5.SetActive(false);
        corruption5.SetActive(false);
        corruption6.SetActive(false);
        corruption7.SetActive(false);
        corruption8.SetActive(false);
        corruption9.SetActive(false);
        corruption10.SetActive(false);
        corruption11.SetActive(false);
        corruption12.SetActive(false);
        corruption13.SetActive(false);
        corruption14.SetActive(false);
        corruption15.SetActive(false);
        corruption16.SetActive(false);
        corruption17.SetActive(false);
        corruption18.SetActive(false);
        corruption19.SetActive(false);
        corruption20.SetActive(false);
        corruption21.SetActive(false);
        corruption22.SetActive(false);
        corruption23.SetActive(false);
        corruption24.SetActive(false);
        corruption25.SetActive(false);
        corruption26.SetActive(false);
        corruption27.SetActive(false);
        corruption28.SetActive(false);
        corruption29.SetActive(false);
        corruption30.SetActive(false);
        corruption31.SetActive(false);

    }


}
