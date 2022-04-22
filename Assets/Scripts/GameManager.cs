using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Timer
    private float timer = 10.9f;
    private float overallTime = 0.0f;

    // Player stats
    private float score = 0;
    private int distanceFromBall = 0;
    private int lives = 3;
    private bool pause = false;

    // Components
    [SerializeField]
    private TileGrid tileGrid;
    [SerializeField]
    private GameObject pickUpObject;
    [SerializeField]
    private GameObject player;


    // HUD references
    [SerializeField, Header("UI Elements")]
    TextMeshProUGUI scoreText;
    [SerializeField]
    TextMeshProUGUI timerText;
    [SerializeField]
    TextMeshProUGUI distance;
    [SerializeField]
    TextMeshProUGUI livesText;

    [SerializeField, Header("GameOver Elements")]
    private GameObject gameoverHUD;
    [SerializeField]
    private TextMeshProUGUI gameoverScoreText;
    [SerializeField]
    private TextMeshProUGUI gameoverTimeText;

    [SerializeField, Header("Pause HUD")]
    private GameObject pauseHUD;

    // Update is called once per frame
    void Update()
    {
        if (!pause)
        {
            // Update timer and check if 10 secs up
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                TimerRunOut();
            }

            // Get player distance from the ball
            distanceFromBall = (int)Vector3.Distance(player.transform.position, pickUpObject.transform.position);

            UpdateHUD();
        }
    }

    private void UpdateHUD()
    {
        scoreText.text = "[score] " + score;
        timerText.text = ((int)timer).ToString() + "s";
        distance.text = distanceFromBall + "m";
        livesText.text = "[lives] " + lives;
    }

    private void TimerRunOut()
    {
        LoseLives();
        timer = 10.9f;
        overallTime += 10.9f;
    }

    // When a pick up is collect, spawn another one
    public void AddPickUp()
    {
        // Add score
        score += 10;

        // Set timer
        overallTime += 10.9f - timer;
        timer = 10.9f;

        // Place pick up elsewhere
        pickUpObject.transform.position = tileGrid.GetPickUpSpawnPos().position;
    }

    public void LoseLives()
    {
        if (player)
        {
            player.GetComponent<AudioSource>().Play();
        }
        lives--;
        if (lives <= 0)
        {
            pause = true;
            gameoverScoreText.text = "SCORE\n" + score;
            gameoverTimeText.text = "SURVIVAL TIME\n" + (int)overallTime + " sec.";
            gameoverHUD.SetActive(true);
            gameoverHUD.GetComponent<AudioSource>().Play();
        }
        
    }

    public void Pause()
    {
        pause = true;
        pauseHUD.SetActive(true);
    }

    public void Resume()
    {
        pause = false;
        pauseHUD.SetActive(false);
    }

    public bool GamePaused()
    {
        return pause;
    }
}
