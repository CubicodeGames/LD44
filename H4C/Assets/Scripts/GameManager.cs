using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    public FollowCam cam;
    public Character heart;
    public Character coin;

    public Goal goal;

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

        heart.active = true;
        coin.active = false;

        cam.target = heart.transform;
    }

    void Update()
    {
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
                heart.active = !heart.active;
                coin.active = !coin.active;

                if (heart.active)
                {
                    cam.target = heart.transform;
                }
                else
                {
                    cam.target = coin.transform;
                }
            }
        }
    }

    public void GameOver()
    {
        Debug.Log("GAME OVER");
    }
}
