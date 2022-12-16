using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LapTime : MonoBehaviour
{
    public static int minuteCount;
    public static int secondCount;
    public static float millisecondCount;
    public static string millisecondDisplay;

    public GameObject minuteBox;
    public GameObject secondBox;
    public GameObject millisecondBox;

    private GameManager gameManager;
    private CountDown countDown;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        countDown = GameObject.Find("Count Down").GetComponent<CountDown>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive && countDown.isCountDownEnd)
        {
            millisecondCount += Time.deltaTime * 10;
            millisecondDisplay = millisecondCount.ToString("F0");
            millisecondBox.GetComponent<TextMeshProUGUI>().text = "" + millisecondDisplay;

            // In this function we are updating lap time with one second when 10 milliseconds passed 
            if (millisecondCount >= 10)
            {
                millisecondCount = 0;
                secondCount += 1;
            }

            // In this function we are updating lap time seconds into double digit
            if (secondCount <= 9)
            {
                secondBox.GetComponent<TextMeshProUGUI>().text = "0" + secondCount + ".";
            }
            else
            {
                secondBox.GetComponent<TextMeshProUGUI>().text = "" + secondCount + ".";
            }

            // In this function we are update laptime with one minute when 60 seconds passed
            if (secondCount >= 60)
            {
                secondCount = 0;
                minuteCount += 1;
            }

            // In this function we are updating lap time minutes into double digit
            if (minuteCount <= 9)
            {
                minuteBox.GetComponent<TextMeshProUGUI>().text = "0" + minuteCount + ":";
            }
            else
            {
                minuteBox.GetComponent<TextMeshProUGUI>().text = "" + minuteCount + ":";
            }
        }
    }
}
