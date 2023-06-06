﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    private float timer = 0;
    private bool isTimerRunning = false;

    public PlatformTriggerScript startPlatform;

    public PlatformTriggerScript endPlatform;

    public TextMeshProUGUI timerText;

    public bool isTimerSet = false;

    void Start()
    {

        ResetTimer();

    }

    void Update()
    {
        if (isTimerRunning && isTimerSet)
        {
            timer += Time.deltaTime;
        }

        if (isTimerSet && !startPlatform.PlayerInsideZone())
        {
            StartTimer();
        }
        if (isTimerRunning && endPlatform.PlayerInsideZone())
        {
            StopTimer();
        }
        if (!isTimerSet && startPlatform.PlayerInsideZone())
        {
            ResetTimer();
        }

        UpdateUI();
    }

    public void UpdateUI()
    {
        timerText.text = $"Time: {timer:#.00}";
    }

    public void ResetTimer()
    {
        timer = 0;
        isTimerSet = true;
    }

    public void StartTimer()
    {
        isTimerRunning = true;
    }

    public void StopTimer()
    {
        isTimerRunning = false;
        isTimerSet = false;
        Victory();
    }

    public void Victory() {

        var audioPlayer = GameObject.Find("SoundEffect").GetComponent<AudioSource>();

        var winningSound = GameObject.Find("SoundEffect").GetComponent<SoundEffects>().GetSoundEffect("Success");

        audioPlayer.PlayOneShot(winningSound);

    }

    public float CurrentTimer()
    {
        return timer;
    }
}
