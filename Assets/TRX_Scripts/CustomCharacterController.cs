using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*  Ce Controller est fait pour être utilisé avec un Rigidbody2D et donc tirer parti de la Physique d'Unity.
    Il est conçu pour un set de mécanique et un gamefeel spécifique au projet RUINS. Pour le bon fonctionnement 
    des presets du script , les paramètres du Rigidbody2D doivent êtres réglés à Mass = 1.3 et Gravity Scale = 4*/

public class CustomCharacterController : MonoBehaviour
{
    // Déclarations
    public enum GroundType
    {
        ground,
        wallJump,
        none
    }

    public static AudioClip playerFall;
    static AudioSource audioSrc;
    public Animator animator;

    public bool jumpInput = false;
    float hKeyInput;
    bool isJumping = false;
    bool isFalling = false;
    public bool canJump = true;
    public bool canImpulse = false;
    bool enableMouv = true;
    bool unfreeze = false;
    bool isLeftWallJump = false;


    [SerializeField] float acceleration = 0.0f;
    [SerializeField] float maxSpeed = 0.0f;
    [SerializeField] float maxYSpeed = 0.0f;
    [SerializeField] float fallSpeed = 0.0f;
    [SerializeField] float jumpForce = 12.0f;
    [SerializeField] float jumpHForce = 4.0f;
    [SerializeField] float impulseHForce = 6.0f;
    [SerializeField] float impulseForce = 12.0f;
    [SerializeField, Range(0f,0.50f)] float jumpBuffering = 0.04f;
    public float speedInfo;

    SpriteRenderer playerSprite;
    Rigidbody2D playerRigidbody;
    //BoxCollider2D playerCollider;
    Collider2D playerCollider;

    LayerMask groundLayer;
    LayerMask wallJumpLayer;
    GroundType groundType;

    Vector2 movementInput;
    Vector2 velocity;
    Vector2 impulseDir = new Vector2(0f, 0f);
    Vector2 jumpDir = new Vector2(0f, 0f);
    Vector2 wallJump = new Vector2(3.5f, 16.0f);

    RaycastHit2D[] rGroundCast;
    RaycastHit2D[] rWallCast;

    Vector4 cameraInitialPosition;
    public float shakeMagnitude = 0.05f;
    public float shakeTime = 0.05f;
    [SerializeField] private GameObject mainCamera;

    public bool isGrounded;

    private GameObject LowCam;
    private GameObject LargeCam;
    private GameObject MainCam;

    public bool CameraLow;
    public bool CameraLarge;
    public bool CameraMain;

    public AudioSource walkingSrc;
    public AudioClip walking;

    SoundManager[] soundM;

    private void Awake()
    {
        LowCam = GameObject.Find("Camera_Low");
        LargeCam = GameObject.Find("Camera_Large");
        MainCam = GameObject.Find("Main Camera");
    }

    void Start()
    {
        playerSprite = gameObject.GetComponent<SpriteRenderer>();
        playerRigidbody = gameObject.GetComponent<Rigidbody2D>();
        //playerCollider = gameObject.GetComponent<BoxCollider2D>();
        playerCollider = gameObject.GetComponent<Collider2D>();
        groundLayer = LayerMask.GetMask("Ground");
        wallJumpLayer = LayerMask.GetMask("WallJump");

       rGroundCast = new RaycastHit2D[10];
       rWallCast = new RaycastHit2D[10];

     
    }
    
    public void Update()
    {
        InputCheck();
        animator.SetFloat("Speed", Mathf.Abs(speedInfo));
        ClampVelocity();
        CameraSwitch();

        if (CameraLow == true)
        {
            mainCamera = LowCam;
        }

        if (CameraLarge == true)
        {
            mainCamera = LargeCam;
        }

        if (CameraMain == true)
        {
            mainCamera = MainCam;
        }

        if (isGrounded == true)
        {
            ShakeIt();
        }

        if(Input.GetAxisRaw("Horizontal") != 0)
        { 
           
        }
        else
        { 
            
        }



    }
    
    void FixedUpdate()
    {
        GroundingUpdate();
        VelocityUpdate();
        JumpDirection();
        JumpUpdate();
        WallJump();
    }

    public void CameraSwitch()
    {
        if (CameraMain == true)
        {
            MainCam.SetActive(true);
            LowCam.SetActive(false);
            LargeCam.SetActive(false);
        }

        if (CameraLow == true)
        {
            MainCam.SetActive(false);
            LowCam.SetActive(true);
            LargeCam.SetActive(false);
        }

        if (CameraLarge == true)
        {
            MainCam.SetActive(false);
            LowCam.SetActive(false);
            LargeCam.SetActive(true);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("CameraLow"))
        {
            Debug.Log("camlow find");
            MainCam.SetActive(false);
            LowCam.SetActive(true);
            LargeCam.SetActive(false);
            CameraLow = true;
            CameraLarge = false;
            CameraMain = false;
        }

        if (collision.CompareTag("CameraLarge"))
        {
            Debug.Log("camlarge find");
            MainCam.SetActive(false);
            LowCam.SetActive(false);
            LargeCam.SetActive(true);
            CameraLarge = true;
            CameraLow = false;
            CameraMain = false;

        }

        if (collision.CompareTag("MainCamera"))
        {
            Debug.Log("cammain find");
            MainCam.SetActive(true);
            LowCam.SetActive(false);
            LargeCam.SetActive(false);
            CameraMain = true;
            CameraLarge = false;
            CameraLow = false;
        }
    }

        // Méthodes
    void ClampVelocity()
    {
        velocity = playerRigidbody.velocity;
        velocity.y = Mathf.Clamp(velocity.y, -fallSpeed, maxYSpeed);
        playerRigidbody.velocity = velocity;

    }

    void InputCheck()
    {

        //Détection du mouvement horizontal
        hKeyInput = Input.GetAxisRaw("Horizontal");
        movementInput = new Vector2(hKeyInput, 0);

        //Détection du Saut
        if (Input.GetButtonDown("Jump"))
        {
            jumpInput = true;
            StartCoroutine("JumpBuffering");

            if (canJump) animator.SetBool("isJumping", true);
            
            if (canJump == true)
            {
                FindObjectOfType<SoundManager>().PlaySound("Jump");
            }
        }
        else
        {
            animator.SetBool("isJumping", false);
        }

    }

    void JumpDirection()
    {
        //Change la direction du vecteur utilisé pour l'impulsion (ImpulseDir) en fonction de l'input directionnel (hKeyInupt)
        if (hKeyInput > 0)
        {
            impulseDir = new Vector2(impulseHForce, impulseForce);
        }
        else if (hKeyInput < 0)
        {
            impulseDir = new Vector2(-impulseHForce, impulseForce);
        }
        else
        {
            impulseDir = new Vector2(0f, impulseForce);
        }

        //De même pour la direction du vecteur de saut (JumpDirection)

        if (hKeyInput > 0)
        {
            jumpDir = new Vector2(jumpHForce, jumpForce);
        }
        else if (hKeyInput < 0)
        {
            jumpDir = new Vector2(-jumpHForce, jumpForce);
        }
        else
        {
            jumpDir = new Vector2(0f, jumpForce);
        }

    }

    void VelocityUpdate()
    {

        velocity = playerRigidbody.velocity; //Donne la vélocité du rigidbody du player à une variable locale (velocity) pour pouvoir la modifier
        speedInfo = playerRigidbody.velocity.x; //Renvoie la vitesse du player pour pouvoir l'utiliser dans l'animation

        if (hKeyInput == 0) //supprime l'inertie
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, 0.85f);
            playerRigidbody.velocity = velocity;
        }
        else if (enableMouv)
        {
            //Applique les changements voulus à la vélocité
            velocity += movementInput * Time.fixedDeltaTime * acceleration; 

            movementInput = Vector2.zero;//L'input de mouvement a été consommé, on le réinitialise

            velocity.x = Mathf.Clamp(velocity.x, -maxSpeed, maxSpeed);

            //Tourne le sprite dans la direction vers laquelle on se dirige
            if (Input.GetAxis("Horizontal") < 0f) 
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
               
            }
            else if (Input.GetAxis("Horizontal") > 0f)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
                
            }
            
            //Smoothing collision with walls
            int numHits = playerCollider.Cast(-Vector2.left, rWallCast, 0.3f);
            if (numHits > 0) velocity += new Vector2 (-1.2f,0);

            int leftNumHits = playerCollider.Cast(Vector2.left, rWallCast, 0.3f);
            if (leftNumHits > 0) velocity += new Vector2(1.2f, 0); ;

            if (isFalling) velocity.x = 0.85f * velocity.x;

            //Rend la vélocité au rigidbody du player
            playerRigidbody.velocity = velocity;
                               
        }
    }

    void JumpUpdate()
    {
        //Mise à jour du marqueur de chute 
        if (isJumping && playerRigidbody.velocity.y < 0)
        {
            isFalling = true;
        }
        //
        if (isJumping && isFalling)
        {
            canJump = false;
        }

        //Saut de base
        if (jumpInput && groundType == GroundType.ground && canJump)
        {

            playerRigidbody.AddForce(jumpDir, ForceMode2D.Impulse); //Remplacer le simple Add force par quelque chose avec plus de contrôle.
            animator.SetBool("isJumping", true);
            //Mise à jour des marqueurs après le saut
            jumpInput = false;//L'input de saut à été consommé, on le réinitialise
            isJumping = true;
            canImpulse = true;

        }

        //WallJump
        else if (jumpInput && groundType == GroundType.wallJump)
        {
            /* //Setup des raycasts pour détecter les murs de WallJump à gauche ou à droite
             int wallHitsLeft = playerCollider.Raycast(Vector2.left, rWallCast, 1.3f, wallJumpLayer);
             int wallHitsRight = playerCollider.Raycast(-Vector2.left, rWallCast, 1.3f, wallJumpLayer);
             */

            //saut
            if (isLeftWallJump)
            {
                transform.position = transform.position + new Vector3(0.4f, 0.6f, 0);

                //Saut
                velocity = playerRigidbody.velocity;
                velocity = velocity + new Vector2(wallJump.x, wallJump.y);
                playerRigidbody.velocity = velocity;

                jumpInput = false;
                isJumping = true;
                canImpulse = true;
            }
            else if (!isLeftWallJump)
            {
                transform.position = transform.position + new Vector3(-0.4f, 0.6f, 0);

                //Saut
                velocity = playerRigidbody.velocity;
                velocity = velocity + new Vector2(-wallJump.x, wallJump.y);
                playerRigidbody.velocity = velocity;

                jumpInput = false;
                isJumping = true;
                canImpulse = true;
            }
        }

        //Impulsion après un Saut
        else if (jumpInput && canImpulse)
        {
            StartCoroutine("Impulse");
        }

        //Aterissage
        else if (isFalling && groundType != GroundType.none)
        {
            isJumping = false;
            isFalling = false;
            unfreeze = false;

            isGrounded = true;
            FindObjectOfType<SoundManager>().PlaySound("Player Ground Impact");
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
            isGrounded = false;
    }

    public IEnumerator Impulse()
    {
        //freeze position
        enableMouv = false;
        playerRigidbody.constraints = RigidbodyConstraints2D.FreezePosition | RigidbodyConstraints2D.FreezeRotation;
        animator.SetBool("isImpulsing", true);
        yield return new WaitForSeconds(0.24f);
        unfreeze = true;
        if (unfreeze/*Condition validée dans la coroutine après le temps de freeze*/)
        {
            animator.SetBool("isImpulsing", false);
            //unfreeze position
            playerRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;

            //Impulsion
            velocity = playerRigidbody.velocity;
            velocity = impulseDir;
            playerRigidbody.velocity = velocity;

            //Mise à jour des marqueurs après l'impulsion
            enableMouv = true;
            jumpInput = false;

            isJumping = true;
            canImpulse = false;
        }
        StopCoroutine("Impulse");
    }

    void WallJump()
    {
        //Ralentissement sur un WallJump
        if (groundType == GroundType.wallJump)
        {
            //bug : saut sur le mur pour remonter quand aucun input directionnel pressé
            velocity = playerRigidbody.velocity;
            if (!isJumping) velocity.y = velocity.y * 0.80f;
            playerRigidbody.velocity = velocity;
        }
    }

    void GroundingUpdate()
    {
        //Setup des raycast pour mettre à jour le grounding
        RaycastHit2D hitLeftFoot = Physics2D.Raycast(new Vector3((transform.position.x - 0.3f), transform.position.y, transform.position.z), -Vector2.up, 1.4f, (groundLayer | wallJumpLayer));
        RaycastHit2D hitRightFoot = Physics2D.Raycast(new Vector3((transform.position.x + 0.3f), transform.position.y, transform.position.z), -Vector2.up, 1.4f, (groundLayer | wallJumpLayer));
        Debug.DrawRay(new Vector3((transform.position.x - 0.3f), transform.position.y, transform.position.z), -Vector2.up, Color.green);
        Debug.DrawRay(new Vector3((transform.position.x + 0.3f), transform.position.y, transform.position.z), -Vector2.up, Color.green);

        //int numHits = playerCollider.Raycast(-Vector2.up, rGroundCast, 1.3f, (groundLayer | wallJumpLayer));
        int wallHitsLeft = playerCollider.Raycast(Vector2.left, rWallCast, 0.8f, wallJumpLayer);
        int wallHitsRight = playerCollider.Raycast(-Vector2.left, rWallCast, 0.8f, wallJumpLayer);

        //Grounding au sol
        if ((hitLeftFoot.collider != null) || (hitRightFoot.collider != null))
        {
            groundType = GroundType.ground;
            canJump = true;
            animator.SetBool("isGrinding", false);

        }
        //Grounding sur un mur de WallJump
        else if (wallHitsLeft > 0)
        {
            print("touché gauche");
            groundType = GroundType.wallJump;
            isLeftWallJump = true;
            canJump = true;
            animator.SetBool("isGrinding", true);
        }
        else if (wallHitsRight > 0)
        {
            print("touché droit");
            groundType = GroundType.wallJump;
            isLeftWallJump = false;
            canJump = true;
            animator.SetBool("isGrinding", true);

        }
        //Pas de Grounding (vide)
        else
        {
            groundType = GroundType.none;
            canJump = false;
            animator.SetBool("isGrinding", false);

        }
    }

    public IEnumerator JumpBuffering()
    {
        yield return new WaitForSeconds(jumpBuffering);
        jumpInput = false;
        Debug.Log(jumpInput);

    }

}