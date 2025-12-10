using UnityEngine;

public class LetterSpawner : MonoBehaviour
{
    public GameObject letterPrefab;
    public float spawnInterval = 2f;
    public Vector2 spawnYRange = new Vector2(-1f, 2f);

    private string targetWord;

    void Start()
    {
        // Pull the correct word from GameManager
        targetWord = GameManager.Instance.targetWord;

        InvokeRepeating(nameof(SpawnLetter), 2f, spawnInterval);
    }

    void SpawnLetter()
    {
        char letter;

        // 20% fake letter
        if (Random.value < 0.2f)
        {
            do
            {
                letter = (char)Random.Range('A', 'Z' + 1);
            }
            while (targetWord.Contains(letter));
        }
        else
        {
            // 80% correct letter
            letter = targetWord[Random.Range(0, targetWord.Length)];
        }

        Vector3 spawnPos = new Vector3(
            10f,
            Random.Range(spawnYRange.x, spawnYRange.y),
            0
        );

        GameObject obj = Instantiate(letterPrefab, spawnPos, Quaternion.identity);
        obj.GetComponent<LetterBar>().letter = letter;
    }
}
