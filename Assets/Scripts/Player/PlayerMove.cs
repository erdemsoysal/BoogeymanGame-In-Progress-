using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    CharacterController playerController;
    public float speed = 3;
    public float gravity = 9.8f;
    public Transform playerCamera;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    #region Movement
    Vector3 moveVector;
    private void PlayerMovement()
    {
        moveVector = new Vector3(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, Input.GetAxis("Vertical") * speed * Time.deltaTime);
        moveVector = playerCamera.TransformDirection(moveVector);
        gravityEffect();
        playerController.Move(moveVector);
    }
    #endregion

    #region Gravity
    void gravityEffect()
    {
        if (!playerController.isGrounded)
        {
            moveVector.y -= Time.deltaTime * gravity;
        }
    }
    #endregion
}
