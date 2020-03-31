using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayManager : MonoBehaviour
{
    public GameObject originalPipe;
    public float pipeSpacing = 3f;
    public float gapRange = 1f;
    public GameObject canvasGameOver;
    public Text textScore;
    public Text textBestScore;
    public int score = 0;
    public int best = 0;
    public bool gameOver = false;

    void Start()
    {
        GenerateLevel();
        if (PlayerPrefs.HasKey("BEST"))
        {
            best = PlayerPrefs.GetInt("BEST");
        }
    }
    void Update()
    {
        
    }
    public void GenerateLevel()
    {
        for(int i=0; i<10; i++)
        {
            GameObject pipe = Instantiate(originalPipe);
            pipe.transform.position = new Vector3(i * pipeSpacing, Random.Range(-gapRange, gapRange), 0);
        }
    }

    public void GameOver()
    {
        gameOver = true;
        canvasGameOver.SetActive(true);
        textBestScore.text = PlayerPrefs.GetInt("BEST").ToString();
    }

    public void AddScore()
    {
        if (gameOver)
            return;

        score++;
        textScore.text = score.ToString();

        if(score > best)
        {
            PlayerPrefs.SetInt("BEST", score);
            PlayerPrefs.Save();
        }
        
    }

    public void ResetBestScore()
    {
        PlayerPrefs.SetInt("BEST", 0);
        PlayerPrefs.Save();
    }
}
