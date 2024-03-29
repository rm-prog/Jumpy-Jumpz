using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelSelector : MonoBehaviour
{

    public Button[] buttons;

    private void Awake()
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        PlayerPrefs.SetInt("ReachedIndex", 3);
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
            if (i < unlockedLevel)
            {
                buttons[i].interactable = true;
            }
        }
    }

    public void OpenScene(int level)
    {
        SceneManager.LoadScene("Level " + level);
    }

}
