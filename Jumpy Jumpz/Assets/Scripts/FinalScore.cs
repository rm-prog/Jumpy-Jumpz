using TMPro;
using UnityEngine;

public class FinalScore : MonoBehaviour
{

    public GameObject ScoreText;

    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = ScoreText.GetComponent<TextMeshProUGUI>().text;    
    }

}
