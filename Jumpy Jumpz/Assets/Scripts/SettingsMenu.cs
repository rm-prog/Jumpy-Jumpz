using UnityEngine;

public class SettingsMenu : MonoBehaviour
{

    public TimedClickButton tiltButton;
    public TimedClickButton arrowsButton;

    private string control;

    void Start()
    {
        control = PlayerPrefs.GetString("turnSettings", "tilt");
        PlayerPrefs.SetString("turnSettings", control);
        if (control == "tilt")
        {
            tiltButton.interactable = false;
            arrowsButton.interactable = true;
        } else if (control == "arrows")
        {
            tiltButton.interactable = true;
            arrowsButton.interactable = false;
        }
    }

    public void TiltButtonClick()
    {
        PlayerPrefs.SetString("turnSettings", "tilt");
        tiltButton.interactable = false;
        arrowsButton.interactable = true;
    }

    public void ArrowsButtonClick()
    {
        PlayerPrefs.SetString("turnSettings", "arrows");
        tiltButton.interactable = true;
        arrowsButton.interactable = false;
    }

    void OnDestroy()
    {
        PlayerPrefs.Save();    
    }

}
