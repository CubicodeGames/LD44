using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    public FollowCam cam;
    public Character heart;
    public Character coin;
    public TradingPlatform[] tradingPlatforms;
    public Goal goal;

    public Slider heartEnergy;
    public Slider coinEnergy;
    public TextMeshProUGUI heartsCollected;
    public TextMeshProUGUI coinsCollected;
    public Image key1;
    public Image key2;
    public Canvas pauseMenu;
    public AudioSource exchangeSound;

    public bool IsGameOver { get; private set; }
    public bool IsLevelComplete { get; private set; }
    public string GameOverReason { get; private set; }

    private Color _key1Color;
    private Color _key2Color;
    public bool _isPaused;

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

        _isPaused = false;
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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!_isPaused)
            {
                Time.timeScale = 0;
                pauseMenu.gameObject.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                pauseMenu.gameObject.SetActive(false);
            }

            _isPaused = !_isPaused;
        }

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
            foreach (TradingPlatform tp in tradingPlatforms)
            {
                tp.gameObject.SetActive(true);
            }

            goal.gameObject.SetActive(true);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            if (tradingPlatforms.Any(tp => tp.BothIn))
            {
                ExchangePickups();
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

        heartEnergy.value = heart.CurrentHealth / heart.startHealth;
        coinEnergy.value = coin.CurrentHealth / coin.startHealth;

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

        exchangeSound.Play();
    }

    public void GameOver(string reason)
    {
        IsGameOver = true;
        GameOverReason = reason;
        Debug.Log($"GAME OVER: {reason}");
        SceneManager.LoadScene("GameOver");
    }  
    
    public void LevelComplete()
    {
        if (!IsLevelComplete)
        {
            Debug.Log("LEVEL COMPLETE");
            IsLevelComplete = true;
            SceneManager.LoadScene("LevelComplete");
        }
    }

    public void Continue()
    {
        Time.timeScale = 1;
        pauseMenu.gameObject.SetActive(false);
        _isPaused = false;
    }
}
