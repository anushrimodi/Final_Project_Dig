using UnityEngine;

[RequireComponent(typeof(LetterBar))]
public class LetterCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.AddLetter(
                GetComponent<LetterBar>().letter
            );

            Destroy(gameObject);
        }
    }
}
