using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectItems : MonoBehaviour
{
    public Camera camera;
    public Image crosshair;
    [Header("DOOR")]
    public Animator doorAnim;
    [Header("LIGHTS")]
    public Light bedSideLight;
    public Light Room1Light;

    // Start is called before the first frame update
    void Start()
    {
        bedSideLight.enabled = false;
        Room1Light.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        crosshair.color = Color.white;
        DetectItemScript();
    }

    private void DetectItemScript()
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position,camera.transform.forward,out hit,2))
        {
            // [LIGHT SECTION]
            #region bedSideLight
            if (hit.collider.gameObject.tag == "lightSwitch")
            {
                crosshair.color = Color.red;
                if (Input.GetKeyDown(KeyCode.F))
                {
                    bedSideLight.enabled = !bedSideLight.enabled;
                }
            }
            #endregion
            #region Room1Light
            if (hit.collider.gameObject.tag == "lightSwitchRoom1")
            {
                crosshair.color = Color.red;
                if (Input.GetKeyDown(KeyCode.F))
                {
                    Room1Light.enabled = !Room1Light.enabled;
                }
            }
            #endregion

            // [DOOR]

            #region Door
            if (hit.collider.gameObject.tag == "Door")
            {
                crosshair.color = Color.red;
                doorAnim = hit.collider.GetComponentInChildren<Animator>();
                if (Input.GetKeyDown(KeyCode.F))
                {
                    doorAnim.SetTrigger("OpenClose");
                }
            }
            #endregion


        }
    }
}
