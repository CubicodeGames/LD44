using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelCompleteController : MonoBehaviour
{
    public Button continueButton;
    public Button restartButton;
    public TextMeshProUGUI allLevelCompleted;

    void Start()
    {
        bool hasNextLevel = LevelManager.Instance.HasNextLevel();

        allLevelCompleted.gameObject.SetActive(!hasNextLevel);
        continueButton.gameObject.SetActive(hasNextLevel);
        restartButton.gameObject.SetActive(!hasNextLevel);
    }
}
