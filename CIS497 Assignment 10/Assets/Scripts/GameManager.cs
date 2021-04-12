/* * Logan Ross 
 * * GameManger.cs 
 * * Assignment 10
 * * spawns obstacles and checks for game over
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    ObjectPooler objectPooler;
    public bool gameOver = false;
    public int roundScore;
    public int bestScore = 0;

    public Text txtScore;
    public GameObject gameOverPanel;
    public GameObject smFound;

    public ScoreManager smPrefab;

    private void Start()
    {
        smFound = GameObject.FindGameObjectWithTag("ScoreManager");
        if (smFound == null)
        {
            Instantiate(smPrefab);
            smFound = GameObject.FindGameObjectWithTag("ScoreManager");
        }

        bestScore = smFound.GetComponent<ScoreManager>().bestScore;

        Time.timeScale = 1f;
        gameOver = false;
        objectPooler = ObjectPooler.Instance;
        StartCoroutine(spawnObstacles());
    }

    public void FixedUpdate()
    {
        if(gameOver)
        {
            Time.timeScale = 0f;
            ActivateGameOverScreen();
        }
        else
        {
            roundScore++;
            txtScore.text = "Score: " + roundScore.ToString();
        }
    }

    IEnumerator spawnObstacles()
    {
        Debug.Log("start spawn");
        while(true)
        {
            Debug.Log("spawn");

            yield return new WaitForSeconds(Random.Range(1f, 3f));
            objectPooler.SpawnFromPool("Obstacle", transform.position, Quaternion.identity);
        }
    }

    public void resartButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public Text RoundScore;
    public Text BestScore;

    public void ActivateGameOverScreen()
    {
        RoundScore.text = "Round Score: " + roundScore;

        if(roundScore > bestScore)
        {
            bestScore = roundScore;
            smFound.GetComponent<ScoreManager>().bestScore = bestScore;
        }

        BestScore.text = "Best Score: " + bestScore;
        gameOverPanel.SetActive(true);
    }

}
