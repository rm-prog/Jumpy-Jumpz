using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody rb;

    public float linearSpeed = 30f; // 12f
    public readonly float verticalJumpSpeed = 7f; // 5f
    private readonly float horizontalInputMultiply = 25.0f;
    private float velocityZ = 0f;

    private Boolean leftOrRight = false;

    private String turnSettings;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GetComponent<MeshFilter>().sharedMesh.UploadMeshData(false);
        turnSettings = PlayerPrefs.GetString("turnSettings", "arrows");
        PlayerPrefs.SetString("turnSettings", turnSettings);
    }

    void Update()
    {

        if (Input.GetKeyDown("w"))
        {
            rb.velocity = new Vector3(rb.velocity.x, verticalJumpSpeed, rb.velocity.z);
        }

        linearSpeed += 0.001f;
    }

    public void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, verticalJumpSpeed, rb.velocity.z);
    }

    void FixedUpdate()
    {
        if (turnSettings == "tilt")
        {
            if (Input.acceleration.x > 0.005 || Input.acceleration.x < -0.005)
            {
                rb.velocity = new Vector3(linearSpeed, rb.velocity.y, Input.acceleration.x * -horizontalInputMultiply);
            }
            else
            {
                rb.velocity = new Vector3(linearSpeed, rb.velocity.y, rb.velocity.z);
            }
        }
        else if (turnSettings == "arrows")
        {
            rb.velocity = new Vector3(linearSpeed, rb.velocity.y, rb.velocity.z);
            if (!leftOrRight)
            {
                if (velocityZ < 0) velocityZ += 5.0f;
                else if (velocityZ > 0) velocityZ -= 5.0f;
                rb.velocity = new Vector3(linearSpeed, rb.velocity.y, velocityZ);
            }
            leftOrRight = false;
        }
    }

    public void Left()
    {
        leftOrRight = true;
        velocityZ = 10.0f;
        rb.velocity = new Vector3(linearSpeed, rb.velocity.y, velocityZ);
    }

    public void Right()
    {
        leftOrRight = true;
        velocityZ = -10.0f;
        rb.velocity = new Vector3(linearSpeed, rb.velocity.y, velocityZ);
    }

    private void OnDestroy()
    {
        PlayerPrefs.Save();
    }

}
