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
    [SerializeField] private List<Light> lights;

    PlayerMove playerMove;

    // Start is called before the first frame update
    void Start()
    {
        #region Lights
        for(int i = 0; i < lights.Count; i++)
        {
            lights[i].enabled = false;
        }
        // Hallway on
        lights[2].enabled = true;

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

            for (int i = 0; i < lights.Count; i++)
            {
                if (lights[i].transform.parent.name == hit.collider.gameObject.name)
                {
                    crosshair.color = Color.red;
                    if (Input.GetButtonDown("Interact"))
                    {
                        lights[i].enabled = !lights[i].enabled;
                    }
                }
            }

            // [DOOR]

            #region Door
            if (hit.collider.gameObject.tag == "Door")
            {
                crosshair.color = Color.red;
                doorAnim = hit.collider.GetComponentInChildren<Animator>();
                if (Input.GetButtonDown("Interact"))
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
                if (Input.GetButtonDown("Interact") && !isSleeping)
                {
                    playerCam.transform.position = new Vector3(-3.153f, 0.748f, -0.943f);
                    playerCam.transform.rotation = Quaternion.Euler(0,0,90);
                    isSleeping = true;
                    if (isSleeping)
                    {
                        playerMove.speed = 0;
                    }

                }
                else if (Input.GetButtonDown("Interact") && isSleeping)
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
