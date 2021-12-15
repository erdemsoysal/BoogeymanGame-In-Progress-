using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameTime : MonoBehaviour
{
    [SerializeField] public TMPro.TextMeshPro phoneTime;

    private float hours;
    private float minutes;

    private string hourStr;
    private string minuteStr;
    private string str;
    // Start is called before the first frame update
    void Start()
    {
        hours = 22f;
        minutes = 0f;

        hourStr = "22";
        minuteStr = "00";

        phoneTime.text = $"{hourStr}:{minuteStr}";
    }

    // Update is called once per frame
    void Update()
    {
        minutes += 1f * Time.deltaTime / 10f; // 1 minute every 10 seconds
        if (minutes >= 60f)
        {
            hours += 1f;
            if (hours >= 24f)
                hours = 0f;
            hourStr = ((int)hours / 10).ToString() + ((int)hours % 10).ToString();
            minutes = 0f;
            minuteStr = "00";
            phoneTime.text = $"{hourStr}:{minuteStr}";
        }
        if (minutes - Mathf.Floor(minutes) >= 0.9f)
        {
            minuteStr = ((int)minutes / 10).ToString() + ((int)minutes % 10).ToString();
            phoneTime.text = $"{hourStr}:{minuteStr}";
        }
    }
}
