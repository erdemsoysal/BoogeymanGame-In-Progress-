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
    [Header("SLEEP")]
    public GameObject playerCam;
    public bool isSleeping;
    [Header("LIGHTS")]
    public Light bedSideLight;
    public Light Room1Light;
    public Light HallwayLight;
    public Light CorridorLight;
    public Light Room2Light;
    public Light BathroomLight;
    public Light Room3Light;
    public Light LivingRoom1Light;
    public Light LivingRoom2Light;
    public Light KitchenLight;


    PlayerMove playerMove;
    // Start is called before the first frame update
    void Start()
    {
        #region Lights
        bedSideLight.enabled = false;
        Room1Light.enabled = false;
        //HallwayLight.enabled = false;
        CorridorLight.enabled = false;
        Room2Light.enabled = false;
        BathroomLight.enabled = false;
        Room3Light.enabled = false;
        LivingRoom1Light.enabled = false;
        LivingRoom2Light.enabled = false;
        KitchenLight.enabled = false;

        #endregion

        isSleeping = false;
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
            #region HallwayLight
            if (hit.collider.gameObject.tag == "lightSwitchHallway")
            {
                crosshair.color = Color.red;
                if (Input.GetKeyDown(KeyCode.F))
                {
                    HallwayLight.enabled = !HallwayLight.enabled;
                }
            }
            #endregion
            #region CorridorLight
            if (hit.collider.gameObject.tag == "lightSwitchCorridor")
            {
                crosshair.color = Color.red;
                if (Input.GetKeyDown(KeyCode.F))
                {
                    CorridorLight.enabled = !CorridorLight.enabled;
                }
            }
            #endregion
            #region Room2Light
            if (hit.collider.gameObject.tag == "lightSwitchRoom2")
            {
                crosshair.color = Color.red;
                if (Input.GetKeyDown(KeyCode.F))
                {
                    Room2Light.enabled = !Room2Light.enabled;
                }
            }
            #endregion
            #region BathroomLight
            if (hit.collider.gameObject.tag == "lightSwitchBathroom")
            {
                crosshair.color = Color.red;
                if (Input.GetKeyDown(KeyCode.F))
                {
                    BathroomLight.enabled = !BathroomLight.enabled;
                }
            }
            #endregion
            #region Room3Light
            if (hit.collider.gameObject.tag == "lightSwitchRoom3")
            {
                crosshair.color = Color.red;
                if (Input.GetKeyDown(KeyCode.F))
                {
                    Room3Light.enabled = !Room3Light.enabled;
                }
            }
            #endregion
            #region LivingRoom1Light
            if (hit.collider.gameObject.tag == "lightSwitchLivingRoom1")
            {
                crosshair.color = Color.red;
                if (Input.GetKeyDown(KeyCode.F))
                {
                    LivingRoom1Light.enabled = !LivingRoom1Light.enabled;
                }
            }
            #endregion
            #region LivingRoom2Light
            if (hit.collider.gameObject.tag == "lightSwitchLivingRoom2")
            {
                crosshair.color = Color.red;
                if (Input.GetKeyDown(KeyCode.F))
                {
                    LivingRoom2Light.enabled = !LivingRoom2Light.enabled;
                }
            }
            #endregion
            #region KitchenLight
            if (hit.collider.gameObject.tag == "lightSwitchKitchen")
            {
                crosshair.color = Color.red;
                if (Input.GetKeyDown(KeyCode.F))
                {
                    KitchenLight.enabled = !KitchenLight.enabled;
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

            // [LAYING ON BED]
            #region Laying On Bed [IN PROGRESS]

            if (hit.collider.gameObject.tag == "Bed")
            {
                crosshair.color = Color.red;
                playerMove = GetComponent<PlayerMove>();
                if (Input.GetKeyDown(KeyCode.F) && !isSleeping)
                {
                    playerCam.transform.position = new Vector3(-3.153f, 0.748f, -0.943f);
                    playerCam.transform.rotation = Quaternion.Euler(0,0,90);
                    isSleeping = true;
                    if (isSleeping)
                    {
                        playerMove.speed = 0;
                    }

                }
                else if (Input.GetKeyDown(KeyCode.F) && isSleeping)
                {
                    playerMove.speed = 3;
                    playerCam.transform.localPosition = new Vector3(0, 0.656f, 0);
                    isSleeping = false;
                }
            }
            

            #endregion

        }
    }
}
