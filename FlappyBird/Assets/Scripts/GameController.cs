using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public bool isEndGame;
    int gamePoint = 0;
    public Text txtPoint;
    public GameObject pnlEndGame;
    public Text txtEndPoint;
    //Button
    public Button btnRestart;
    //Create animation button when you hover, click in button
    public Sprite btnIdleRestart;
    public Sprite btnHoverRestart;
    public Sprite btnClickRestart;
    //set time when you start
    bool isStartFirstTime = true;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        isEndGame = false;
        isStartFirstTime = true;
        pnlEndGame.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isEndGame)
        {
            if (Input.GetMouseButton(0) && isStartFirstTime)
            {
                startGame();
            }
        }
        else
        {
            if (Input.GetMouseButton(0))
            {
                Time.timeScale = 1;
            }
        }
        
    }

    public void GetPoint()
    {
        gamePoint++;
        txtPoint.text = "Point: " + gamePoint.ToString();
    }

    //Click btnRestart to restart game
    void startGame()
    {
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        startGame();
    }

    //Animation button
    public void btnRestartClick()
    {
        btnRestart.GetComponent<Image>().sprite = btnClickRestart;
    }

    public void btnRestartHover()
    {
        btnRestart.GetComponent<Image>().sprite = btnHoverRestart;
    }

    public void btnRestartIdle()
    {
        btnRestart.GetComponent<Image>().sprite = btnIdleRestart;
    }
    public void EndGame()
    {
        isEndGame = true;
        isStartFirstTime = false;
        Time.timeScale = 0;
        pnlEndGame.SetActive(true);
        txtEndPoint.text = "Your point:\n" + gamePoint.ToString();
    }
}
