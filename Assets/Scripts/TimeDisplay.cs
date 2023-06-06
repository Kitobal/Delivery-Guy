using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeDisplay : MonoBehaviour
{
    Text timeText;
    GameSession gameSession;
    // Start is called before the first frame update
    void Start()
    {
        timeText = GetComponent<Text>();
        gameSession = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    void Update(){
        timeText.text = System.Math.Round(gameSession.GetTime()).ToString();
        }
}