using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public AudioSource aSource;
    public AudioClip buttonSound;
    
    public GameObject menuPanel;
    public GameObject levelPanel;
    public GameObject settingsPanel;

    public Button level1;
    public Button level2;
    public Button level3;
    public Button level4;
    public Button level5;
    public Button level6;
    public Button level7;
    public Button level8;
    public Button level9;
    public Button level10;



    private void Awake()
    {
        
    }

    void Start()
    {
        level1.interactable=true;
        level2.interactable=false;
        level3.interactable=false;
        level4.interactable=false;
        level5.interactable=false;
        level6.interactable=false;
        level7.interactable=false;
        level8.interactable=false;
        level9.interactable=false;
        level10.interactable=false;
        
        InMenuController.instance.soundLock = false;
        menuPanel.SetActive(true);
        levelPanel.SetActive(false);
        settingsPanel.SetActive(false);
    }

    private void Update()
    {
        if (LEVELCOMPLETE.instance.level2b)
        {
            level2.interactable=true;
        }
        if (LEVELCOMPLETE.instance.level3b)
        {
            level3.interactable=true;
        }
        if (LEVELCOMPLETE.instance.level4b)
        {
            level4.interactable=true;
        }
        if (LEVELCOMPLETE.instance.level5b)
        {
            level5.interactable=true;
        }
        if (LEVELCOMPLETE.instance.level6b)
        {
            level6.interactable=true;
        }if (LEVELCOMPLETE.instance.level7b)
        {
            level7.interactable=true;
        }
        if (LEVELCOMPLETE.instance.level8b)
        {
            level8.interactable=true;
        }
        if (LEVELCOMPLETE.instance.level9b)
        {
            level9.interactable=true;
        }
        if (LEVELCOMPLETE.instance.level10b)
        {
            level10.interactable=true;
        }
    }

    public void PlaySound()
    {
        if(InMenuController.instance.soundLock!)
        {
            aSource.clip = buttonSound;
            aSource.Play();
        }
    }

    public void Mute()
    {
        InMenuController.instance.soundLock = false;
    }
    public void UnMute()
    {
        InMenuController.instance.soundLock= true;
    }
    public void Menu()
    {
        menuPanel.SetActive(true);
        levelPanel.SetActive(false);
        settingsPanel.SetActive(false);
    }
    public void Settings()
    {
        menuPanel.SetActive(false);
        levelPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }
    public void Level()
    {
        menuPanel.SetActive(false);
        levelPanel.SetActive(true);
        settingsPanel.SetActive(false);
    }

    public void Back()
    {
        menuPanel.SetActive(true);
        levelPanel.SetActive(false);
        settingsPanel.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void Level1()
    {
        SceneManager.LoadScene("Level 1");
        Time.timeScale = 1;
    }
    public void Level2()
    {
        SceneManager.LoadScene("Level 2");
        Time.timeScale = 1;
    }
    public void Level3()
    {
        SceneManager.LoadScene("Level 3");
        Time.timeScale = 1;
    }
    public void Level4()
    {
        SceneManager.LoadScene("Level 4");
        Time.timeScale = 1;
    }
    public void Level5()
    {
        SceneManager.LoadScene("Level 5");
        Time.timeScale = 1;
    }
    public void Level6()
    {
        SceneManager.LoadScene("Level 6");
        Time.timeScale = 1;
    }
    public void Level7()
    {
        SceneManager.LoadScene("Level 7");
        Time.timeScale = 1;
    }
    public void Level8()
    {
        SceneManager.LoadScene("Level 8");
        Time.timeScale = 1;
    }
    public void Level9()
    {
        SceneManager.LoadScene("Level 9");
        Time.timeScale = 1;
    }
    public void Level10()
    {
        SceneManager.LoadScene("Level 10");
        Time.timeScale = 1;
    }
}
