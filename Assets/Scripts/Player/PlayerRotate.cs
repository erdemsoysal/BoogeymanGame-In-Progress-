using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{

    public float sensitivity = 3;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotatePlayer();
    }


    private float rotY;
    private float rotX;
    void rotatePlayer()
    {
        rotY += sensitivity * Input.GetAxis("Mouse Y")*-1;
        rotX += sensitivity * Input.GetAxis("Mouse X");
        rotY = Mathf.Clamp(rotY, -80, 80);
        transform.eulerAngles = new Vector3(rotY, rotX,0);
    }
}
