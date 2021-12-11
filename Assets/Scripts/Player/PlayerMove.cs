using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    CharacterController playerController;
    public float speed = 3;
    public float gravity = 9.8f;


    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();


    }
    
    
    Vector3 moveVector;
    private void PlayerMovement()
    {
        moveVector = new Vector3(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, Input.GetAxis("Vertical") * speed * Time.deltaTime);
        moveVector = transform.TransformDirection(moveVector);
        gravityEffect();
        playerController.Move(moveVector);



    }
   
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
