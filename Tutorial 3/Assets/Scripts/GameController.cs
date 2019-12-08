using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public AudioClip MusicClip;

    public AudioSource MusicSource;
    public AudioClip DefeatClip;
    public AudioSource DefeatSource;
    public Text scoreText;
    public Text restartText;
    public Text gameOverText;
    public Text winText;
    public Text livesText;

    private bool gameOver;
    private bool restart;
    public int score;
    public float lives;


    void Start()
    {

        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        winText.text = "";
        lives = 3;
        SetLivesText();
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
        MusicSource.clip = MusicClip;
        DefeatSource.clip = DefeatClip;

    }

    void Update()
    {
        if (Input.GetButton("Cancel"))
        {
            Application.Quit();
        }
        if (restart)
        {
            if (Input.GetKeyDown (KeyCode.X))
            {
                SceneManager.LoadScene("Space Shooter Tut 3");
            }
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.text = "Press 'X' for Restart";
                restart = true;
                break;
            }
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    public void UpdateScore()
    {
        scoreText.text = "Points: " + score;
        if (score >= 150)
        {
            winText.text = "You win! Game Created by Steven Pineda!";
            gameOver = true;
            restart = true;
            MusicSource.Play();
        }
    }
   public void SetLivesText()
    {
        livesText.text = "Lives: " + lives;
        if (lives <= 0)
        {
            gameOver = true;
        }
    }

    public void GameOver ()
    {
        DefeatSource.Play();
        gameOverText.text = "Game Over!";
        gameOver = true;
    }
     
}