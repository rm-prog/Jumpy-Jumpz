using UnityEngine;

public class ShadowFollow : MonoBehaviour
{

    public Transform player;

    private readonly float positionY = 0.08f;

    private float offsetX = 5.0f;

    private readonly float playerStartingHeight = 5.0f;

    private readonly float maxScale = 4.0f;

    private readonly float scaleMultiplier = 0.3f;
    

    void FixedUpdate()
    {

        offsetX = player.position.y;

        transform.position = new Vector3(player.position.x + offsetX, positionY, player.position.z);

        float scale = 1.0f;

        if (player.position.y < 1.0f) 
        {
            scale = 1.5f + (1 - player.position.y)*3;
        } 
        else if (player.position.y < 3.0f)
        {
            scale = 1 + (3 - player.position.y)*0.75f;
        } 

        transform.localScale = new Vector3(
                                        scale, 
                                        transform.localScale.y, 
                                        scale
                                           );
    }

}
