using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject CompleteLevelPanel;
    public GameObject GamePanel;
    public GameObject GameOverPanel;

    public GameObject Player;

    public bool IsEndlessRunner;

    public void EndGame()
    {
        if (!IsEndlessRunner) Restart();
        else
        {
            GameOverPanel.SetActive(true);
            GamePanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void CompleteLevel()
    {
        CompleteLevelPanel.SetActive(true);
        Player.SetActive(false);
        GamePanel.SetActive(false);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
