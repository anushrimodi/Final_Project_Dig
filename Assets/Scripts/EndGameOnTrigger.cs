using UnityEngine;

public class EndGameOnTrigger : MonoBehaviour
{
    private bool hasDied = false;
    public GameObject restartButton; 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (hasDied) return;   // prevents multiple triggers

        if (other.GetComponent<BirdController>())
        {
            hasDied = true;

            Debug.Log("Game Over");

            // 🔊 Play death sound here
            AudioManager.Instance.PlayLose();

            // OPTIONAL: show restart button if it's separate
            if (restartButton != null)
                restartButton.SetActive(true);

            // ⏸ Pause game AFTER sound plays (optional: add delay if needed)
            Time.timeScale = 0f;
        }
    }
}
