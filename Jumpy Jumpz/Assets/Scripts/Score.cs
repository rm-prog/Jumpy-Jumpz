using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{

    public Transform PlayerTransfrom;

    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = PlayerTransfrom.position.x.ToString("0");
    }
}

