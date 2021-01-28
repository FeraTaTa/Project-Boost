using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    [SerializeField]
    float seconds = 0f;
    [SerializeField]
    float minutes = 0f;
    [SerializeField]
    TMP_Text timerText;
    
    public bool timerStarted;

    // Start is called before the first frame update
    void Start()
    {
        timerText = GetComponentInChildren<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timerStarted)
        {
            countUpTimer();

        }
        else
        {

        }
    }

    private void countUpTimer()
    {
        seconds += Time.deltaTime;

        if (seconds > 60)
        {
            minutes++;
            seconds = 0;
        }
        timerText.text = string.Format("{0:00}:{1:00.000}", minutes, seconds);
    }
}
