using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void About()
    {
        SceneManager.LoadScene("About");
    }

    public void Back()
    {
        SceneManager.LoadScene("Main");
    }

    public void NextLevel()
    {
        string nextLevelName = LevelManager.Instance.GetNextLevelName();
        SceneManager.LoadScene(nextLevelName);
    }

    public void Continue()
    {
        GameManager.Instance.Continue();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void Controls()
    {
        ControlsController.Instance.ShowControls();
    }

    public void Close()
    {
        ControlsController.Instance.HideControls();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
