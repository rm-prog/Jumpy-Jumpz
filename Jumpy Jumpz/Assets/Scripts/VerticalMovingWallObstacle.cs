using UnityEngine;

public class VerticalMovingWallObstacle : MonoBehaviour
{

    private float startingPositionY;
    // pos1, pos2 two points between which moves the MovingWallObstacle
    private Vector3 pos1;
    private Vector3 pos2;
    // the speed at which the object moves between the two points
    public float speed;
    // should object first go up or down
    public bool up;

    // Start is called before the first frame update
    void Start()
    {
        startingPositionY = transform.position.y;
        pos1 = new Vector3(transform.position.x, startingPositionY - 2, transform.position.z);
        pos2 = new Vector3(transform.position.x, startingPositionY + 2, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (up) transform.position = Vector3.Lerp(pos1, pos2, Mathf.PingPong(Time.time * speed, 1.0f));
        else transform.position = Vector3.Lerp(pos2, pos1, Mathf.PingPong(Time.time * speed, 1.0f));
    }
}
