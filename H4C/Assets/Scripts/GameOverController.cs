using TMPro;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    public TextMeshProUGUI reason;

    void Start()
    {
        reason.text = GameManager.Instance.GameOverReason;
    }
}
