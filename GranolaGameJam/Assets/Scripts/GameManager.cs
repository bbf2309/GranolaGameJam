using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public float score;
    public float winConn;
    public TextMeshProUGUI scoreDisplay;
    public TimerScript timer;

    // Start is called before the first frame update
    void Start()
    {
        score = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        scoreDisplay.text = "Score: "+score.ToString()+"   Target Score: "+winConn.ToString();
        if(score >= winConn)
        {
            WinScreen();
        }
        if (!timer.TimerOn)  
        { 
            LoseScreen();
        }
    }

    public void WinScreen()
    {
        SceneManager.LoadScene("WinScene");
    }

    public void LoseScreen()
    {
        SceneManager.LoadScene("LoseScene");
    }
}
