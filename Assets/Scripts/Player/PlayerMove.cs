using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("Player")]
    public Transform playerCamera;
    CharacterController playerController;
    [Header("Movement Values")]
    public float speed = 2;
    public float gravity = 9.8f;
    [Header("Movement Indicators")]
    public float moveHorizontal;
    public float moveVertical;

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
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        moveVector = new Vector3(moveHorizontal * speed * Time.deltaTime, 0, moveVertical * speed * Time.deltaTime);
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
