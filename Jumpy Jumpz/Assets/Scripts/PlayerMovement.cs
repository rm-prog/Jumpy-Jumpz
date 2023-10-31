using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody rb;

    private float linearSpeed = 12f;

    private float verticalJumpSpeed = 5f;

    private float horizontalInputMultiply = 20.0f;

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

        //if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        //{
            //rb.velocity = new Vector3(rb.velocity.x, verticalJumpSpeed, rb.velocity.z);
        //}

        linearSpeed += 0.001f;

    }

    public void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, verticalJumpSpeed, rb.velocity.z);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Player should move forward in constant speed and move horizontally, when A or D is clicked
        // Player should jump if w button is clicked
        // rb.velocity = new Vector3(linearSpeed, rb.velocity.y, -horizontalInput * horizontalInputMultiply);
        rb.velocity = new Vector3(linearSpeed, rb.velocity.y, Input.acceleration.x * -horizontalInputMultiply);

    }

}
