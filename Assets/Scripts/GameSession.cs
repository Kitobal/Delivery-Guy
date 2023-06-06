using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    int score = 0;
    float timeRemaining = 120f;
    private void Awake()
    {
        SetUpSingleton();
    }
    private void SetUpSingleton()
    {
        int numberGameSession = FindObjectsOfType<GameSession>().Length;
        if (numberGameSession > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    public int GetScore()
    {
        return score;
    }
    public void AddToScore(int points)
    {
        score += points;
    }
    public void ResetGame()
    {
        Destroy(gameObject);
    }

    public float GetTime()
    {
        return timeRemaining;
    }
    void Update(){

        if(SceneManager.GetSceneByName("Game").isLoaded){
            if (timeRemaining > 0)
            {
            timeRemaining = timeRemaining - Time.deltaTime;

            }
            else{
            FindObjectOfType<LevelLoader>().LoadGameOver();
            }
        }
        
    }
    public void addTime(){
        timeRemaining += 5;
    }
}

