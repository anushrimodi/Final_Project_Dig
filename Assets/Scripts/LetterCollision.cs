using UnityEngine;

[RequireComponent(typeof(LetterBar))]
public class LetterCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            char thisLetter = GetComponent<LetterBar>().letter;

            // 1. Wrong letter sound
            if (!GameManager.Instance.targetWord.Contains(thisLetter))
            {
                AudioManager.Instance.PlayWrong();
                Destroy(gameObject);
                return;
            }

            // 2. Correct letter case
            bool added = GameManager.Instance.AddLetterAndReturnIfNew(thisLetter);

            if (added)
                AudioManager.Instance.PlayCollect();

            Destroy(gameObject);
        }
    }
}
