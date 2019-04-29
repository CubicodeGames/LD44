using TMPro;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    public TextMeshProUGUI reason;
    public AudioSource gameOverSound;

    void Start()
    {
        reason.text = GameManager.Instance.GameOverReason;
    }
}
