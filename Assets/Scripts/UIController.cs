using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    public GameObject winPanel;
    public GameObject losePanel;
    public GameObject pausePanel;

    public AudioSource aSource;
    public AudioClip clickSound;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        pausePanel.SetActive(false);
        losePanel.SetActive(false);
        winPanel.SetActive(false);
    }

    public void Click()
    {
        aSource.clip = clickSound;
        aSource.Play();
    }

    public void Pause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void Resume()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }
    
    public void Lose()
    {
        losePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Win()
    {
        winPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void Level2()
    {
        LEVELCOMPLETE.instance.Level1();
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }
    public void Level3()
    {
        LEVELCOMPLETE.instance.Level2();
        SceneManager.LoadScene(3);
        Time.timeScale = 1;
    }
    public void Level4()
    {
        LEVELCOMPLETE.instance.Level3();
        SceneManager.LoadScene(4);
        Time.timeScale = 1;
    }
    public void Level5()
    {
        LEVELCOMPLETE.instance.Level4();
        SceneManager.LoadScene(5);
        Time.timeScale = 1;
    }
    public void Level6()
    {
        LEVELCOMPLETE.instance.Level5();
        SceneManager.LoadScene(6);
        Time.timeScale = 1;
    }
    public void Level7()
    {
        LEVELCOMPLETE.instance.Level6();
        SceneManager.LoadScene(7);
        Time.timeScale = 1;
    }
    public void Level8()
    {
        LEVELCOMPLETE.instance.Level7();
        SceneManager.LoadScene(8);
        Time.timeScale = 1;
    }
    public void Level9()
    {
        LEVELCOMPLETE.instance.Level8();
        SceneManager.LoadScene(9);
        Time.timeScale = 1;
    }
    public void Level10()
    {
        LEVELCOMPLETE.instance.Level9();
        SceneManager.LoadScene(10);
        Time.timeScale = 1;
    }
}
