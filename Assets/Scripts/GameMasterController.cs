using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameMasterController : MonoBehaviour
{
    public static GameMasterController Instance;
    public void Awake() => Instance = this;
    [SerializeField]
    private Transform cameraTransform = null;
    public TextMeshProUGUI ScoreText;
    [SerializeField]
    private GameObject DeathPanel = null;
    [SerializeField]
    private TextMeshProUGUI DeathScore = null;
    [SerializeField]
    private TextMeshProUGUI DeathHighScore = null;
    [SerializeField]
    private TextMeshProUGUI DeathCoins = null;
    [SerializeField]
    private TextMeshProUGUI CoinsAmount = null;
    private int coins = 0;

    [SerializeField]
    private GameObject LifeContainer = null;
    [SerializeField]
    private GameObject HeartPrefab = null;


    private void Start()
    {
        DeathPanel.SetActive(false);
        InitLifePanel();
    }
    public int GetScore()
    {
        return Mathf.RoundToInt(cameraTransform.position.y);
    }

    public void UpdateScore()
    {
        ScoreText.text = GetScore().ToString();
    }

    private void LateUpdate()
    {
        UpdateScore();
    }

    public void ShowDeathPanel()
    {
        DeathPanel.SetActive(true);
        int score = GetScore();
        DeathScore.text = score.ToString();
        int hs = PlayerPrefs.GetInt("highScore", 0);
        if (hs < score)
        {
            hs = score;
            PlayerPrefs.SetInt("highScore", hs);
        }
        DeathHighScore.text = hs.ToString();
        DeathCoins.text = GetCoins().ToString();
        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins", 0) + GetCoins());
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene("Game");
    }
    public void OpenMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void AddCoins(int amount = 1)
    {
        coins = coins + amount;
        UpdateCoins();
    }
    public void UpdateCoins()
    {
        CoinsAmount.text = coins.ToString();
    }
    public int GetCoins()
    {
        return coins;
    }
    private void InitLifePanel()
    {
        for (int i = 0; i < LifeContainer.transform.childCount; i++)
        {
            Destroy(LifeContainer.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < Player.Instance.MaxHealth; i++)
        {
            Instantiate(HeartPrefab, LifeContainer.transform);
        }
    }


}
