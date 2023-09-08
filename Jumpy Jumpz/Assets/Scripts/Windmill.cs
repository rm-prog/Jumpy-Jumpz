using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Windmill : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(1.0f, 0.0f, 0.0f, Space.Self);
    }
}
