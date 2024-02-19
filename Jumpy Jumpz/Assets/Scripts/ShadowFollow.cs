using UnityEngine;

public class ShadowFollow : MonoBehaviour
{

    public Transform player;

    private readonly float positionY = 0.08f;

    private float offsetX = 5.0f;

    private readonly float scaleMultiplier = 0.5f;
    

    void FixedUpdate()
    {

        offsetX = player.position.y;

        transform.position = new Vector3(player.position.x + offsetX, positionY, player.position.z);

        transform.localScale = new Vector3(scaleMultiplier * player.position.y, transform.localScale.y, scaleMultiplier * player.position.y);

    }

}
