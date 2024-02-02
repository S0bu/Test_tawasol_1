using System.Collections;
using System.Collections.Generic;
using Unity.Android.Gradle.Manifest;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController playerController;
    public Transform cam;

    [SerializeField] private float speed = 6f;
    [SerializeField] private float turnSmoothning = 0.1f;
    [SerializeField] private float turnVelocity = 0.0f;
    [SerializeField] private float jumpForce = 4f;
    [SerializeField] private float gravity = 9.8f;

    private float horizontalInput;
    private float verticalInput;
    //private Vector3 playerVelocity;

    private void Start()
    {
        playerController = GetComponent<CharacterController>();
    }

    void Update()
    {
        //if (playerController.isGrounded)
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 _dir = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        if (_dir.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(_dir.x, _dir.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnVelocity, turnSmoothning);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            playerController.Move(moveDir.normalized * speed * Time.deltaTime);
        }

                //For jumping mechanism
                /*if (Input.GetKeyDown(KeyCode.Space))
                {
                    playerVelocity.y = jumpForce;
                    playerVelocity.x = moveDir.x;
                    playerVelocity.z = moveDir.z;
                }
                if(playerVelocity.y > 0f)
                    playerVelocity.y -= gravity * Time.deltaTime;

                playerController.Move((speed * moveDir.normalized + playerVelocity) * Time.deltaTime);*/
        /*else
        {
            playerVelocity.y -= gravity * Time.deltaTime;
            playerController.Move(playerVelocity * Time.deltaTime);
        }*/
    }
}