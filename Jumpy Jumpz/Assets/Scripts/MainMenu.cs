using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(2);
    }

    public void EndlessRunner()
    {
        SceneManager.LoadScene(1);
    }
}
