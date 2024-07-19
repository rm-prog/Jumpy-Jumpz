using UnityEngine;

public class ArrowsActive : MonoBehaviour
{

    public HoldClickButton leftArrow;
    public HoldClickButton rightArrow;

    void Start()
    {
        if (PlayerPrefs.GetString("turnSettings", "arrows") != "arrows")
        {
            leftArrow.gameObject.SetActive(false);
            rightArrow.gameObject.SetActive(false);
        }
        else
        {
            leftArrow.gameObject.SetActive(true);
            rightArrow.gameObject.SetActive(true);
        }
    }
}
