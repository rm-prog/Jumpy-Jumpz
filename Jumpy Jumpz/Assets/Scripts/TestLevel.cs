using UnityEngine;

public class TestLevel : MonoBehaviour
{
    // Script for testing different project settings

    public GameObject player;
    public GameObject mainCamera;

    void Start()
    {
        Physics.gravity = new Vector3(0, -15f, 0);
        player.GetComponent<PlayerMovement>().verticalJumpSpeed = 7f;
        player.GetComponent<PlayerMovement>().linearSpeed = 30f;
        mainCamera.GetComponent<Camera>().fieldOfView = 40f;
    }

}
