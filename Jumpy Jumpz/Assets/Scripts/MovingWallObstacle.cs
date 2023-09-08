using UnityEngine;

public class MovingWallObstacle : MonoBehaviour
{

    private float startingPositionZ;
    // pos1, pos2 two points between which moves the MovingWallObstacle
    private Vector3 pos1;
    private Vector3 pos2;
    // the speed at which the object moves between the two points
    public float speed;
    // should object first go right or left
    public bool right;

    void Start()
    {
        startingPositionZ = transform.position.z;
        pos1 = new Vector3(transform.position.x, transform.position.y, startingPositionZ-3);
        pos2 = new Vector3(transform.position.x, transform.position.y, startingPositionZ+3);
    }

    void Update()
    {
        if (right) transform.position = Vector3.Lerp(pos1, pos2, Mathf.PingPong(Time.time * speed, 1.0f));
        else transform.position = Vector3.Lerp(pos2, pos1, Mathf.PingPong(Time.time * speed, 1.0f));
    }
}
