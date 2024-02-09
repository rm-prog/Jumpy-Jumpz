using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{

    public int level;

    public void OpenScene()
    {
        SceneManager.LoadScene("Level " + level);
    }

}
