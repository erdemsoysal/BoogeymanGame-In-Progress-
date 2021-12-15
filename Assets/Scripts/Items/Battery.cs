using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    private float batteryPercentage;
    public TMPro.TextMeshPro batteryLevel;

    PlayerItems playerItemsScript;

    // Start is called before the first frame update
    void Start()
    {
        playerItemsScript = GetComponentInParent<PlayerItems>();
        batteryPercentage = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerItemsScript.phoneLight.enabled)
        {
            batteryPercentage -= 1 * Time.deltaTime / 5;
            batteryLevel.text = $"{(int)batteryPercentage}%";
        }
        if (batteryPercentage <= 0)
        {
            batteryPercentage = 0;
        }
        if (batteryPercentage >= 100)
        {
            batteryPercentage = 100;
        }
        
    }
}
