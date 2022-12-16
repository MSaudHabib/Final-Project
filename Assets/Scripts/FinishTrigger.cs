using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        // This function will detect which car wins
       if(collision.gameObject.CompareTag("Car2"))
        {
            gameManager.GameOver("Player Car Wins!!!");       
        }
        else if (collision.gameObject.CompareTag("Car1"))
        {
            gameManager.GameOver("AI Car Wins!!!");
        }
    }
}
