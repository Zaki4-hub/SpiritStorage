using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.Experimental.GraphView;
using System.Net;
using JetBrains.Annotations;

public class Timer : MonoBehaviour
{ 
    [SerializeField] TextMeshProUGUI TimerText;
[SerializeField] AudioSource GhostVoice;
[SerializeField] GameObject ShiftIsOver;
[SerializeField] GameObject Continue;
[SerializeField] GameObject Quit;

float elapsedTime;
int stages = 0;

bool isPaused = false;

bool dayAdvanced = false;

bool shiftShown = false;
bool shiftEnded = false;

void Start()
{
    Time.timeScale = 1f;
    elapsedTime = 0f;
    stages = 0;
    isPaused = false;

    GhostVoice.enabled = false;
    Continue.SetActive(false);
    ShiftIsOver.SetActive(false);
    Quit.SetActive(false);
}

void Update()
{
    if (isPaused) return;

    elapsedTime += Time.deltaTime;

    int minutes = Mathf.FloorToInt(elapsedTime / 60);
    int seconds = Mathf.FloorToInt(elapsedTime % 60);

    TimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    if (minutes == 11 && seconds == 57)
    {
            ChangeMessage();

    }
    if (!dayAdvanced && minutes == 12 && seconds == 0)
    {
            Routine();
        
    }
    
        
    if (minutes == 23 && seconds == 57)
    {
            ChangeMessage();

    }
    if (!dayAdvanced && minutes == 24 && seconds == 0)
    {
            Routine();
    }
    
    
    if (minutes == 35 && seconds == 57)
    {
            ChangeMessage();

    }
    if (!dayAdvanced && minutes == 36 && seconds == 0)
    {
            Routine();
    }

    if(minutes == 36 && seconds == 3)
        {
            GhostVoice.enabled = true;
        }




    }
public void ChangeMessage()
    {
        ShiftIsOver.SetActive(true);
        shiftShown = true;
    }
public void Routine()
    {
        stages = +1;
        dayAdvanced = true;
        ShiftOver();
        shiftEnded = true;

    }
//Pause the timer
public void Pause()
{
    isPaused = true;
    Time.timeScale = 0f;
    Cursor.visible = true;
    Cursor.lockState = CursorLockMode.None;
    }

//Resume the timer
public void Resume()
{
    isPaused = false;
    Time.timeScale = 1f;
    Cursor.visible = false;
    Cursor.lockState = CursorLockMode.Locked;
    }

//Handle shift end logic
void ShiftOver()
{
    Pause();
    Continue.SetActive(true);
    Quit.SetActive(true);
}
}

