using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    //Used to track time for text manager and ends the game while deactivating the Player.
    public float timeRemaining = 30;
    public bool timerRunning = false;
    public TMP_Text timeText;
    public RestartScene RestartScene;
    public Player Player;

    private void Start()
    {
        timerRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("out of time");
                timeRemaining = 0;
                timerRunning = false;

                RestartScene.Setup();
                Player.SetActive();
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("Timer: {00}:{1:00}", minutes, seconds);
    }
}
