using UnityEngine;

public class StartLevel : MonoBehaviour
{

    public GameObject StartPanel;
    public GameObject GamePanel;

    void Start()
    {
        Time.timeScale = 0;        
    }

    public void LevelStart()
    {
        Time.timeScale = 1;
        StartPanel.SetActive(false);
        GamePanel.SetActive(true);
    }
}
