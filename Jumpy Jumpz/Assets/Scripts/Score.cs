using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public Transform PlayerTransfrom;

    void Update()
    {
        GetComponent<TextMeshPro>().text = PlayerTransfrom.position.x.ToString("0");
    }
}
