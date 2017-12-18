using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour {

    public bool recording;
    public bool gamePaused = false;

    private float fixedDeltaTime = 0.02f; 

    void Awake()
    {
        recording = true;
    }

    void Update()
    {
        if (CrossPlatformInputManager.GetButton("Fire1"))
        {
            recording = false; 
        }
        else
        {
            recording = true; 
        }

        if (Input.GetKeyDown(KeyCode.P) && !gamePaused)
        {
            PauseGame();  
        }
        else if(Input.GetKeyDown(KeyCode.P) && gamePaused)
        {
            UnPauseGame();
        }

    }

    void PauseGame()
    {
        Time.timeScale = 0f;
        Time.fixedDeltaTime = 0f;
        gamePaused = true;
    }
    void UnPauseGame()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = fixedDeltaTime;
        gamePaused = false;
    }
}
