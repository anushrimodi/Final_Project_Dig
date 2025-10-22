using UnityEngine;

public class EndGameOnTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<BirdController>())
        {
            Debug.Log("Game Over");
            Time.timeScale = 0f; // pause everything
        }
    }
}
