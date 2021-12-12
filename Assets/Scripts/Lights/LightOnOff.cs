using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOnOff : MonoBehaviour
{
    public Light light;

    public void Start()
    {
        light = GetComponentInChildren<Light>();
    }

    public void Update()
    {
        OnOff();
    }
    public void OnOff() 
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            light.enabled = !light.enabled;
        }
    }
    
}
