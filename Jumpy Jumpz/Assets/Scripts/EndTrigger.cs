using UnityEngine;

public class EndTrigger : MonoBehaviour
{

    public GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {

        // If player reaches end of level
        if (other.gameObject.layer == 6)
        {
            gameManager.CompleteLevel();
        }
    }
}
