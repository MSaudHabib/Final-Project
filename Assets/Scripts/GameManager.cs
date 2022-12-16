using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool isGameActive;
    public GameObject titleText;
    public Button restartButton;
    public Button startButton;
    public GameObject lapLabel;
    public GameObject speedLabel;
    public GameObject winDisplay;
    public GameObject winPanel;
    public GameObject countdownDisplay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // This function is used to over ther game
    public void GameOver(string winner)
    {
        isGameActive = false;
        titleText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        winPanel.gameObject.SetActive(true);
        winDisplay.GetComponent<TextMeshProUGUI>().text = winner;
    }

    // This function is used to restart the game
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // This function is used to the start the game
    public void StartGame()
    {
        isGameActive = true;
        startButton.gameObject.SetActive(false);
        titleText.gameObject.SetActive(false);
        speedLabel.gameObject.SetActive(true);
        lapLabel.gameObject.SetActive(true);
        countdownDisplay.SetActive(true);
    }
}
