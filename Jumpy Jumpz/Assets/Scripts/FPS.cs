using System.Collections;
using UnityEngine;

public class FPS : MonoBehaviour
{
    private float count;

    private IEnumerator Start()
    {
        GUI.depth = 2;
        while (true)
        {
            count = 1f / Time.unscaledDeltaTime;
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 40, 100, 20), "FPS: " + Mathf.Round(count));
    }
}
