using UnityEngine;

public class StartLevel : MonoBehaviour
{

    public GameObject startPanel;
    public GameObject gamePanel;
    public GameObject player;

    void Start()
    {
        Time.timeScale = 0;        
        player.GetComponent<PlayerMovement>().enabled = false;
    }

    public void LevelStart()
    {
        Time.timeScale = 1;
        startPanel.SetActive(false);
        gamePanel.SetActive(true);
        player.GetComponent<PlayerMovement>().enabled = true;
    }
}
