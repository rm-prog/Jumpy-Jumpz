using UnityEngine;

public class ShadowFollow : MonoBehaviour
{

    public Transform player;

    private readonly float positionY = 0.09f;

    private float offsetX = 5.0f;

    private readonly float scaleMultiplier = 0.5f;
    

    void FixedUpdate()
    {
        offsetX = player.position.y;

        if (offsetX < 0 ) transform.position = new Vector3(player.position.x, positionY, player.position.z);
        else transform.position = new Vector3(player.position.x + offsetX, positionY, player.position.z);

        if (player.position.y > 0) transform.localScale = new Vector3(scaleMultiplier * player.position.y, transform.localScale.y, scaleMultiplier * player.position.y);
        else transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
}
