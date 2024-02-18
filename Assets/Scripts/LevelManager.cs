using System;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    private int currentLevel = 1;
    public static LevelManager instance;
    public Button[] levelButtons; // Seviye butonlarını tutmak için dizi

    private void Awake()
    {
        if (instance == null)
        {
            // Eğer LevelManager örneği yoksa, bu örneği atayın ve yok olmasını engelleyin.
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Birden fazla LevelManager örneği oluşturulmaması için bu örneği yok edin.
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        // Önceki seviyeden kaydedilen değeri kontrol etmek için PlayerPrefs kullanıyoruz.
        if (PlayerPrefs.HasKey("CurrentLevel"))
        {
            currentLevel = PlayerPrefs.GetInt("CurrentLevel");
        }

        UpdateLevelButtons();
    }

    public void CompleteLevel()
    {
        // Bir seviye tamamlandığında çağrılacak yöntem.
        currentLevel++;

        // Tamamlanan seviyeyi PlayerPrefs'e kaydedin.
        PlayerPrefs.SetInt("CurrentLevel", currentLevel);

        UpdateLevelButtons();
    }

    public void ResetLevels()
    {
        // Tüm seviye verilerini sıfırla
        currentLevel = 1;
        PlayerPrefs.SetInt("CurrentLevel", currentLevel);

        UpdateLevelButtons();
    }

    private void UpdateLevelButtons()
    {
        // Oynanabilir seviyelerin kilidini kontrol etmek için bir döngü kullanıyoruz.
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i < currentLevel)
            {
                // Bu seviye oynanabilir, butonu etkinleştirin.
                levelButtons[i].interactable = true;
                Debug.Log("Level " + (i + 1) + " is playable.");
            }
            else
            {
                // Bu seviye henüz kilitli, butonu devre dışı bırakın.
                levelButtons[i].interactable = false;
                Debug.Log("Level " + (i + 1) + " is locked.");
            }
        }
    }
}
