using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LEVELCOMPLETE : MonoBehaviour
{
    public static LEVELCOMPLETE instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    public bool level2b;
    public bool level3b;
    public bool level4b;
    public bool level5b;
    public bool level6b;
    public bool level7b;
    public bool level8b;
    public bool level9b;
    public bool level10b;

    void Start()
    {
        level2b=false;
        level3b=false;
        level4b=false;
        level5b=false;
        level6b=false;
        level7b=false;
        level8b=false;
        level9b=false;
        level10b=false;
    }

    void Update()
    {
        
    }

    public void Level1()
    {
        level2b = true;
    }
    public void Level2()
    {
        level3b = true;
    }
    public void Level3()
    {
        level4b = true;
    }
    public void Level4()
    {
        level5b = true;
    }
    public void Level5()
    {
        level6b = true;
    }
    public void Level6()
    {
        level7b = true;
    }
    public void Level7()
    {
        level8b = true;
    }
    public void Level8()
    {
        level9b = true;
    }
    public void Level9()
    {
        level10b = true;
    }
}
