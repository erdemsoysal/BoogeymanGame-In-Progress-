using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    [SerializeField] private GameObject phone;
    [SerializeField] public Light phoneLight;

    // Start is called before the first frame update
    void Start()
    {
        phoneLight.enabled = false;
        phone.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("PhoneOut"))
        {
            phone.SetActive(!phone.activeSelf);
        }
        if(Input.GetButtonDown("ActivateFlashlight") && phone.activeSelf)
        {
            phoneLight.enabled = !phoneLight.enabled;
        }
    }
}
