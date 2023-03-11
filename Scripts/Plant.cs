using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plant : MonoBehaviour
{
    public ParticleSystem waterParticle;
    public GameObject plantParent;
    public Slider slider;
    public Text waterText;
    public Text timerText;

    public TimeSpan timeRemaining;
    
    //The maximum amount of water the plant can hold
    public int maxWater = 100;
    //The amount of water the plant currently has
    private float currentWater;
    //Total amount of time that the plant has before dying
    public float totalTime = 86400f;
    //Current remaining time before the plant dies
    private float currentTime;

    private void Start()
    {
        //Sets max value of the slider to be the same as maxWater
        slider.maxValue = maxWater;
        //Sets 'current' values to max values
        currentWater = maxWater;
        currentTime = totalTime;
        timerText.text = "00:00:00";

        StartCoroutine(UpdateTimer());
    }

    private void Update()
    {
        currentTime -= Time.deltaTime;
        //Sets currentWater to be currentTime that has been converted into % 
        currentWater = currentTime / totalTime * 100;
        slider.value = currentWater;
        waterText.text = currentWater.ToString("0") + "%";

        if (currentWater <= 0)
        {
            Destroy(plantParent);
        }
    }

    public void AddTime()
    {
        if (!(currentTime + totalTime * 0.1f > totalTime))
        {
            currentTime += totalTime * 0.1f;
            waterParticle.Play();
        }
    }

    //Converts currentTime from seconds to a hh:mm:ss format and displays it in timerText
    private IEnumerator UpdateTimer()
    {
        while (true)
        {
            timeRemaining = TimeSpan.FromSeconds(currentTime);
            var timeRemainingStr = timeRemaining.ToString(@"hh\:mm\:ss");
            timerText.text = timeRemainingStr;

            yield return null;
        }
    }
}
