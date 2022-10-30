using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class HUDController : MonoBehaviour
{
    [SerializeField] private TMP_Text countdownText;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private TMP_Text ghostTimerText;
    [SerializeField] private Image Indicator1;
    [SerializeField] private Image Indicator2;
    [SerializeField] private Image Indicator3;
    [SerializeField] private Transform pelletGroup;

    private int milliseconds;
    private int seconds;
    private int minutes;
    private int score;
    private int ghosttimer;
    private bool gameEnabled = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountDown());
    }

    // Update is called once per frame
    void Update()
    {
        if(gameEnabled)
        {
            seconds += (int)Time.time;
            milliseconds += (int)Time.time * 1000;
            if (seconds >= 60)
            {
                minutes++;
                seconds = 0;
            }
            if (milliseconds >= 60)
            {
                milliseconds = 0;
            }
            DisplayTime();
            scoreText.SetText("Score: " + score);
        }
    }

    private void DisplayTime()
    {
        string msString;
        string sString;
        string mString;
        if(milliseconds < 10)
        {
            msString = "0" + milliseconds;
        }
        else
        {
            msString = "" + milliseconds;
        }
        if(seconds < 10)
        {
            sString = "0" + milliseconds;
        }
        else
        {
            sString = "" + seconds;
        }
        if(minutes < 10)
        {
            mString = "0" + minutes;
        }
        else
        {
            mString = "" + minutes;
        }

        timerText.SetText("Time: "+mString+":"+sString+ ":" +msString);
    }

    IEnumerator CountDown()
    {
        countdownText.SetText("3");
        yield return new WaitForSeconds(0.5f);
        countdownText.SetText("2");
        yield return new WaitForSeconds(0.5f);
        countdownText.SetText("1");
        yield return new WaitForSeconds(0.5f);
        countdownText.SetText("GO!");
        yield return new WaitForSeconds(1f);
        countdownText.SetText("");
    }

    public void enableGame()
    {
        gameEnabled = true;
    }

    public void disableGame()
    {
        gameEnabled = false;
    }
}
