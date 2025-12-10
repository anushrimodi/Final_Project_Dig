using UnityEngine;

public class EndGameOnTrigger : MonoBehaviour
{
    private bool hasDied = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (hasDied) return;

        if (other.GetComponent<BirdController>())
        {
            hasDied = true;

            Debug.Log("Game Over");

            // Play sound
            AudioManager.Instance.PlayLose();

            // Show restart button from GameManager
            if (GameManager.Instance.restartButton != null)
                GameManager.Instance.restartButton.SetActive(true);

            // Pause game
            Time.timeScale = 0f;
        }
    }
}
