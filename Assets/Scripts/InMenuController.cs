using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InMenuController : MonoBehaviour
{
    public static InMenuController instance;

    public bool soundLock;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        soundLock = false;
    }

    void Update()
    {
        
    }
}
