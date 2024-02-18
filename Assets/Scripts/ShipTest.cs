using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipTest : MonoBehaviour
{
    public static ShipTest instance;
    public GameObject cannon1;
    public GameObject cannon2;
    public GameObject cannon3;

    public Button shootButton;
    
    public AudioSource aSource;
    public AudioClip shootSound;
    public AudioClip hitSound;
    public AudioClip collectSound;
    public AudioClip winSound;
    public AudioClip loseSound;
    
    private void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        shootButton.onClick.AddListener(Shoot);
        cannon1.SetActive(true);
        cannon2.SetActive(false);
        cannon3.SetActive(false);
    }
    public void ShootSound()
    {
        aSource.PlayOneShot(shootSound);
    }
    public void HitSound()
    {
        aSource.clip = hitSound;
        aSource.Play();
    }
    public void LoseSound()
    {
        aSource.clip = loseSound;
        aSource.Play();
    }
    public void WinSound()
    {
        aSource.clip = winSound;
        aSource.Play();
    }

    public void CollectSound()
    {
        aSource.clip = collectSound;
        aSource.Play();
    }

    public void Shoot()
    {
        if (cannon1.activeSelf)
        {
            cannon1.GetComponent<NewCannon>().Spawn();
        }
        if (cannon2.activeSelf)
        {
            cannon2.GetComponent<NewCannon>().Spawn();
        }
        if (cannon3.activeSelf)
        {
            cannon3.GetComponent<NewCannon>().Spawn();
        }
    }
}