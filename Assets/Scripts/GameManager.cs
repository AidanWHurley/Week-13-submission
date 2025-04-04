using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public GameObject playerPrefab;
    public GameObject enemyOnePrefab;
    public GameObject enemyTwoPrefab;
    public GameObject cloudPrefab;
    public GameObject coinPrefab;

    public TextMeshProUGUI livesText;
    public TextMeshProUGUI scoreText;

    public float horizontalScreenSize;
    public float verticalScreenSize;
    private float verticalHalfLimit = 6.0f;
    private float verticalObjectBottom = 2.5f;

    public int score;

    // Start is called before the first frame update
    //Task 1 (week 13), start sets score to 0, and loads the changescoretext on screen
    void Start()
    {
        horizontalScreenSize = 10f;
        verticalScreenSize = 6.5f;
        score = 0;
        Instantiate(playerPrefab, transform.position, Quaternion.identity);
        CreateSky();
        InvokeRepeating("CreateEnemy", 1, 3);
        InvokeRepeating("CreateEnemyTwo", 10, 3);
        InvokeRepeating("CreateCoin", 5, 3);
        ChangeScoreText(score);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CreateEnemy()
    {
        Instantiate(enemyOnePrefab, new Vector3(Random.Range(-horizontalScreenSize, horizontalScreenSize) * 0.9f, verticalScreenSize, 0), Quaternion.Euler(180, 0, 0));
    }

    //Task two (week 12): part of code that creates second enemy, it has a wider range than the screen and appears slower. It also spawns 10 seconds into the game but moves faster than enemy type one.
    void CreateEnemyTwo()
    {
        Instantiate(enemyTwoPrefab, new Vector3(Random.Range(-10f, 10f) * 0.9f, verticalScreenSize, 0), Quaternion.Euler(180, 0, 0));
    }

    void CreateCoin()
    {
        Instantiate(coinPrefab, new Vector3(Random.Range(-horizontalScreenSize, horizontalScreenSize) * 0.9f, Random.Range(verticalScreenSize* -1 + verticalObjectBottom, verticalScreenSize - verticalHalfLimit), 0), Quaternion.Euler(0, 0, 0));
    }


    void CreateSky()
    {
        for (int i = 0; i < 30; i++)
        {
            Instantiate(cloudPrefab, new Vector3(Random.Range(-horizontalScreenSize, horizontalScreenSize), Random.Range(-verticalScreenSize, verticalScreenSize), 0), Quaternion.identity);
        }

    }
    //Task 1 (week 13), after the score integer updates, the call is made to run the text change command.
    public void AddScore(int earnedScore)
    {
        score = score + earnedScore;
        ChangeScoreText(score);
    }

    public void ChangeLivesText(int currentLives)
    {
        livesText.text = "Lives: " + currentLives;
    }
    //Task 1 (week 13), runs update code to change the text on screen.
    public void ChangeScoreText(int score)
    {
        scoreText.text = "Score: " + score;
    }
}