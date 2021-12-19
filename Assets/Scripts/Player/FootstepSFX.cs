using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSFX : MonoBehaviour
{
    PlayerMove playerMoveScript;
    public AudioSource footstepSFX;
    public float timer;
    public float timeBetweenSteps;
    // Start is called before the first frame update
    void Start()
    {
        playerMoveScript = GetComponentInChildren<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMoveScript.moveHorizontal > 0f || playerMoveScript.moveVertical > 0f || playerMoveScript.moveHorizontal < 0f || playerMoveScript.moveVertical < 0f)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = timeBetweenSteps;
                footstepSFX.Play(); 
            }
            
        }
        else
        {
            timer = timeBetweenSteps;
        }

    }
}