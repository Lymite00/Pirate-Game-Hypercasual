using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Collectables : MonoBehaviour
{
    public static Collectables instance;
    
    public int chestCount;
    public int wineCount;
    public int ammoCount;

    public TextMeshProUGUI chestText;
    public TextMeshProUGUI wineText;
    public TextMeshProUGUI ammoText;
    
    public bool secondCannon;
    public bool canShoot;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        canShoot = true;
        secondCannon = false;
        ammoCount = 10;
    }

    void Update()
    {
        if (ammoCount<=0)
        {
            ammoCount = 0;
            canShoot = false;
        }

        if (ammoCount>0)
        {
            canShoot = true;
        }
        chestText.text = chestCount.ToString("D");
        ammoText.text = ammoCount.ToString("D");
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            PlayerHealthController.instance.TakeDamage(1);
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Chest"))
        {
            ShipTest.instance.CollectSound();
            chestCount += 1;
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Balls"))
        {
            ShipTest.instance.CollectSound();
            ammoCount += 10;
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Wine"))
        {
            ShipTest.instance.CollectSound();
            PlayerHealthController.instance.currentHealth += 1;
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Repair"))
        {
            ShipTest.instance.CollectSound();
            Debug.Log("temas");
            if (!secondCannon)
            {
                ShipTest.instance.cannon2.SetActive(true);
                Destroy(other.gameObject);
                Debug.Log("ilk");
                secondCannon = true;
            }
            else
            {
                ShipTest.instance.cannon3.SetActive(true);
                Destroy(other.gameObject);
                Debug.Log("ikinci");
            }
        }

        if (other.gameObject.CompareTag("Finish"))
        {
            UIController.instance.Win();
            ShipTest.instance.WinSound();
        }
    }
}
