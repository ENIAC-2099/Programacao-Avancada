using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int coinCount;
    public TextMeshProUGUI coinText;
    private int save;

    void Start()
    {
        instance = this;

        coinCount = PlayerPrefs.GetInt("Save");
        coinText.text = "Coin: " + coinCount;
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Save()
    {
        PlayerPrefs.SetInt("Save", coinCount);
    }
}
