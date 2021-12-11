using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectItems : MonoBehaviour
{
    public Camera camera;
    public Image crosshair;
    public GameObject light;

    // Start is called before the first frame update
    void Start()
    {
        light = GetComponentInChildren<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        crosshair.color = Color.white;
        light.SetActive(false);
        DetectItemScript();
    }

    private void DetectItemScript()
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position,camera.transform.forward,out hit,10))
        {
            if (hit.collider.gameObject.tag == "lightSwitch")
            {
                crosshair.color = Color.red;
                if (Input.GetKey(KeyCode.F))
                {
                    light.SetActive(true);
                }
            }
        }
    }
}
