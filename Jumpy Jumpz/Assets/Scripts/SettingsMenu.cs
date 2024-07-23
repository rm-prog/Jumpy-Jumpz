using TMPro;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{

    public TimedClickButton tiltButton;
    public TimedClickButton arrowsButton;
    public TextMeshProUGUI tiltSensText;
    public TextMeshProUGUI arrowsSensText;

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
        tiltSensText.text = PlayerPrefs.GetFloat("tiltMultiplier", 1.0f).ToString("F2");
        arrowsSensText.text = PlayerPrefs.GetFloat("arrowSensitivity", 10.0f).ToString("F2");
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

    public void PlusTilt()
    {
        float tiltMultiplier = PlayerPrefs.GetFloat("tiltMultiplier", 1.0f);
        if (tiltMultiplier < 2.0f) tiltMultiplier += 0.05f;
        tiltMultiplier = Mathf.Round(tiltMultiplier * 100f) / 100f;
        PlayerPrefs.SetFloat("tiltMultiplier", tiltMultiplier);
        PlayerPrefs.Save();
        tiltSensText.text = tiltMultiplier.ToString("F2");
    }

    public void MinusTilt()
    {
        float tiltMultiplier = PlayerPrefs.GetFloat("tiltMultiplier", 1.0f);
        if (tiltMultiplier > 0.5f) tiltMultiplier -= 0.05f;
        tiltMultiplier = Mathf.Round(tiltMultiplier * 100f) / 100f;
        PlayerPrefs.SetFloat("tiltMultiplier", tiltMultiplier);
        PlayerPrefs.Save();
        tiltSensText.text = tiltMultiplier.ToString("F2");
    }

    public void PlusArrow()
    {
        float arrowMultiplier = PlayerPrefs.GetFloat("arrowSensitivity", 10.0f);
        if (arrowMultiplier < 15.0f) arrowMultiplier += 0.5f;
        arrowMultiplier = Mathf.Round(arrowMultiplier * 100f) / 100f;
        PlayerPrefs.SetFloat("arrowSensitivity", arrowMultiplier);
        PlayerPrefs.Save();
        arrowsSensText.text = arrowMultiplier.ToString("F2");
    }

    public void MinusArrow()
    {
        float arrowMultiplier = PlayerPrefs.GetFloat("arrowSensitivity", 10.0f);
        if (arrowMultiplier > 7.0f) arrowMultiplier -= 0.5f;
        arrowMultiplier = Mathf.Round(arrowMultiplier * 100f) / 100f;
        PlayerPrefs.SetFloat("arrowSensitivity", arrowMultiplier);
        PlayerPrefs.Save();
        arrowsSensText.text = arrowMultiplier.ToString("F2");
    }

}
