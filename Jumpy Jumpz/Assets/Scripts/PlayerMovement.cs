using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody rb;

    public float linearSpeed = 30f; // 12f

    public readonly float verticalJumpSpeed = 7f; // 5f

    private readonly float horizontalInputMultiply = 24.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GetComponent<MeshFilter>().sharedMesh.UploadMeshData(false);
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
        if (Input.acceleration.x > 0.005 || Input.acceleration.x < -0.005)
        {
            rb.velocity = new Vector3(linearSpeed, rb.velocity.y, Input.acceleration.x * -horizontalInputMultiply);
        }
        else
        {
            rb.velocity = new Vector3(linearSpeed, rb.velocity.y, rb.velocity.z);
        }
    }

}
