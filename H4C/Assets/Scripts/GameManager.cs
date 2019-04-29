using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    public FollowCam cam;
    public Character heart;
    public Character coin;
    public TradingPlatform tradingPlatform;
    public Goal goal;

    public Slider heartEnergy;
    public Slider coinEnergy;
    public TextMeshProUGUI heartsCollected;
    public TextMeshProUGUI coinsCollected;
    public Image key1;
    public Image key2;

    public bool IsGameOver { get; private set; }
    public bool IsLevelComplete { get; private set; }

    private Color _key1Color;
    private Color _key2Color;

    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        if (Instance != this)
        {
            Destroy(gameObject);
        }

        IsGameOver = false;
        IsLevelComplete = false;

        heart.Active = true;
        coin.Active = false;

        cam.target = heart.transform;

        heartEnergy.value = 1;
        coinEnergy.value = 1;

        heartsCollected.text = "0";
        coinsCollected.text = "0";

        _key1Color = key1.color;
        _key2Color = key2.color;
    }

    void Update()
    {
        if (goal.BothIn)
        {
            LevelComplete();
        }

        if (heart.HasKey)
        {
            _key1Color = new Color(_key1Color.r, _key1Color.g, _key1Color.g, 255);
            key1.color = _key1Color;
        }

        if (coin.HasKey)
        {
            _key2Color = new Color(_key1Color.r, _key1Color.g, _key1Color.g, 255);
            key2.color = _key2Color;
        }

        if (heart.HasKey && coin.HasKey)
        {
            tradingPlatform.gameObject.SetActive(true);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            if (tradingPlatform.BothIn)
            {
                ExchangePickups();
                // Level complete?
            }
            else
            {
                heart.Active = !heart.Active;
                coin.Active = !coin.Active;

                if (heart.Active)
                {
                    cam.target = heart.transform;
                }
                else
                {
                    cam.target = coin.transform;
                }
            }
        }

        heartEnergy.value = heart.CurrentHealth / 100;
        coinEnergy.value = coin.CurrentHealth / 100;

        heartsCollected.text = coin.PickedUpItems.ToString();
        coinsCollected.text = heart.PickedUpItems.ToString();
    }

    private void ExchangePickups()
    {
        int hearts = coin.PickedUpItems;
        int coins = heart.PickedUpItems;

        heart.AddHealth(hearts);
        coin.AddHealth(coins);

        heart.RemovePickups(coins);
        coin.RemovePickups(hearts);
    }

    public void GameOver(string reason)
    {
        IsGameOver = true;
        Debug.Log($"GAME OVER: {reason}");
    }  
    
    public void LevelComplete()
    {
        if (!IsLevelComplete)
        {
            Debug.Log("LEVEL COMPLETE");
            IsLevelComplete = true;
        }
    }
}
