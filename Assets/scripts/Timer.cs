using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText; // Make sure this is assigned in the Inspector
    float elapsedTime;

    void Update()
    {
        elapsedTime += Time.deltaTime; // Update elapsed time
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);    
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }
}
