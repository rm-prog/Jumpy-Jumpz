using JetBrains.Annotations;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    private Rigidbody rb;

    public GameObject segmentProducer;

    protected int segmentEndLayer = 7;
    protected int obstacleLayer = 9;
    protected int groundLayer = 11;

    void Start()
    {
        rb = GetComponent<Rigidbody>();    
    }

    void OnCollisionEnter(Collision collision)
    {
        //If player hits wallObstacle or ground, gameIsOver
        if (collision.gameObject.layer == obstacleLayer || collision.gameObject.layer == groundLayer)
        {
            rb.velocity = new Vector3(0, 0, 0);
            // GetComponent<PlayerMovement>().enabled = false;
            // Debug.Log("Game Over " + collision.gameObject.name);
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // if reach segment end, produce new segment
        if (other.gameObject.layer == segmentEndLayer)
        {
            segmentProducer.GetComponent<SegmentProducer>().ProduceSegment();
        }
    }

}
