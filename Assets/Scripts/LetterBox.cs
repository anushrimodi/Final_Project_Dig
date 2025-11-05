using UnityEngine;
using TMPro;

public class LetterBar : MonoBehaviour
{
    public char letter;
    public TextMeshPro textMesh;
    public float moveSpeed = 3f;

    void Start()
    {
        if (textMesh != null)
            textMesh.text = letter.ToString();
    }

    void Update()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

        if (transform.position.x < -12f)
            Destroy(gameObject);
    }
}
