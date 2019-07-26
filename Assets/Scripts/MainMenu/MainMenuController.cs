using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI CoinsText = null;

    private void Start()
    {
        CoinsText.text = PlayerPrefs.GetInt("Coins", 0).ToString();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void OpenShop()
    {
        SceneManager.LoadScene("Shop");
    }
}
