using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountDown : MonoBehaviour
{
    public bool isCountDownEnd;
    public GameObject countdownDisplay;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Countdown(3));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Countdown(int seconds)
    {
        int count = seconds;

        while (count > 0)
        { 
            yield return new WaitForSeconds(1);
            count--;

            // Displaying coundown
            countdownDisplay.GetComponent<TextMeshProUGUI>().text = count.ToString();
        }

        // Countdown finished
        isCountDownEnd = true;
        countdownDisplay.SetActive(false);
    }
}
