using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{

    //private Rigidbody _rigidbody;
    public float moveSpeed;
    Animator anim;
    private CharacterController _controller;
    private float tDist = 5;

    int isWalkingHash;
    int isRunningHash;
    int isWalkingBackHash;
    int isAttackHash;
    int isDeadHash;

    int isLeftHash;
    int isRightHash;

    int isJumpHash;

    public Transform groundCheckPoint;
    private bool canJump;
    public LayerMask whatIsGround;

    void Start()
    {
 
        anim = GetComponent<Animator>();

        _controller = GetComponent<CharacterController>();

        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
        isWalkingBackHash = Animator.StringToHash("isWalkingBack");
        isAttackHash = Animator.StringToHash("isAttack");
        isDeadHash = Animator.StringToHash("isDead");

        isLeftHash = Animator.StringToHash("isLeft");
        isRightHash = Animator.StringToHash("isRight");

        isJumpHash = Animator.StringToHash("isJump");

    }

    void Update()
    {
        

        Move();
        CaptureBody();
    }

    void Move()
    {

        float ver = Input.GetAxis("Vertical");
        float hor = Input.GetAxis("Horizontal");

        Vector3 playerMovementVer = transform.forward * ver * moveSpeed * Time.deltaTime;
        Vector3 playerMovementHor = transform.right * hor * moveSpeed * Time.deltaTime;

        Vector3 playerMovement = playerMovementVer + playerMovementHor;


        canJump = Physics.OverlapSphere(groundCheckPoint.position, .25f, whatIsGround).Length > 0;


        bool isRunning = anim.GetBool(isRunningHash);
        bool isWalking = anim.GetBool(isWalkingHash);
        bool isWalkingBack = anim.GetBool(isWalkingBackHash);
        bool isAttack = anim.GetBool(isAttackHash);

        bool forwardPressed = Input.GetKey("w");
        bool runPressed = Input.GetKey("left shift");
        bool backwardPressed = Input.GetKey("s");
        bool attackPressed = Input.GetKeyDown(KeyCode.Mouse0);

        bool leftPressed = Input.GetKey("a");
        bool rightPressed = Input.GetKey("d");

        bool isJumpPressed = Input.GetKey("space");

        _controller.Move(playerMovement + ((_controller.isGrounded) ? Vector3.zero : Vector3.down * 100 * Time.deltaTime));



        if (!isWalking && forwardPressed)
        {
            anim.SetBool(isWalkingHash, true);
            moveSpeed = 25;
        }

        if (isWalking && !forwardPressed)
        {
            anim.SetBool(isWalkingHash, false);
        }

        if (!isRunning && (forwardPressed && runPressed))
        {
            anim.SetBool(isRunningHash, true);
            moveSpeed = 50;
        }

        if (isRunning && !forwardPressed || !runPressed)
        {
            anim.SetBool(isRunningHash, false);
            moveSpeed = 25;
        }

        if (!isWalkingBack && backwardPressed)
        {
            anim.SetBool(isWalkingBackHash, true);
            moveSpeed = 10; // çalışmıyor?? geri giderken hızı düşürmüyor.
        }

        if (isWalkingBack && !backwardPressed)
        {
            anim.SetBool(isWalkingBackHash, false);
        }

        if (!isAttack && attackPressed)
        {
            anim.SetBool(isAttackHash, true);
        }

        if (isAttack && !attackPressed)
        {
            anim.SetBool(isAttackHash, false);
        }

        // sol ve sağ denemeleri

        if (!isWalking && leftPressed)
        {
            anim.SetBool(isLeftHash, true);
        }

        if (!leftPressed)
        {
            anim.SetBool(isLeftHash, false);
        }

        if (!isWalking && rightPressed)
        {
            anim.SetBool(isRightHash, true);
        }

        if (!rightPressed)
        {
            anim.SetBool(isRightHash, false);
        }

        if (!isWalking && isJumpPressed && canJump)
        {
            anim.SetBool(isJumpHash, true);
            //Vector3 PlayerJump = transform.up * moveSpeed * Time.deltaTime * 20;
            //_controller.Move(PlayerJump);

        }

        if (!isJumpPressed)
        {
            anim.SetBool(isJumpHash, false);
        }



    }

    void CaptureBody()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GameObject nearBody = FindClosestEnemy();

            if (nearBody != null && nearBody.CompareTag("Elif"))
            {
                //Vector3 velocity = Vector3.zero;
                nearBody.GetComponent<animationStateController>().enabled = true;
                nearBody.GetComponent<ThirdPersonCameraController>().enabled = true;
                nearBody.GetComponent<CharacterController>().enabled = true;

                nearBody.gameObject.tag = "Player";

                nearBody.transform.Find("Camera").gameObject.SetActive(true);
                this.transform.Find("Camera").gameObject.SetActive(false);

                this.gameObject.tag = "Dead";
                this.GetComponent<animationStateController>().enabled = false;
                this.GetComponent<ThirdPersonCameraController>().enabled = false;
                this.anim.SetBool(isDeadHash, true);
                this.GetComponent<CharacterController>().enabled = false;
                

            }
        }
    }

    public GameObject FindClosestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Elif");
        GameObject closest = null;
        float distance = tDist;
        Vector3 position = transform.position;

        foreach (GameObject go in gos)
        {
            if (go == this.gameObject)
                continue;

            float curDistance = Vector3.Distance(go.transform.position, position);
            curDistance = Mathf.Abs(curDistance);

            if (curDistance > tDist)
                continue;

            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }


}
