using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    public FollowCam cam;
    public Character heart;
    public Character coin;
    public Goal goal;

    public TextMeshProUGUI heartsCollected;
    public TextMeshProUGUI coinsCollected;
    public Image key1;
    public Image key2;
    
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

        heart.Active = true;
        coin.Active = false;

        cam.target = heart.transform;

        heartsCollected.text = "0";
        coinsCollected.text = "0";

        _key1Color = key1.color;
        _key2Color = key2.color;
    }

    void Update()
    {
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
            goal.gameObject.SetActive(true);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            if (goal.BothIn)
            {
                // Exchange pickups
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

        heartsCollected.text = coin.PickedUpItems.ToString();
        coinsCollected.text = heart.PickedUpItems.ToString();
    }

    public void GameOver()
    {
        Debug.Log("GAME OVER");
    }
}
