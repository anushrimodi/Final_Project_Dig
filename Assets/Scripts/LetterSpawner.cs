using UnityEngine;

public class LetterSpawner : MonoBehaviour
{
    public GameObject letterPrefab;
    public string targetWord = "UNITY";
    private int nextIndex = 0;

    public float spawnInterval = 3f;
    public Vector2 spawnYRange = new Vector2(-1f, 2f);

    void Start()
    {
        InvokeRepeating(nameof(SpawnNextLetter), 2f, spawnInterval);
    }

    void SpawnNextLetter()
    {
        if (nextIndex >= targetWord.Length)
            return;

        char letter = targetWord[nextIndex];
        Vector3 spawnPos = new Vector3(10f, Random.Range(spawnYRange.x, spawnYRange.y), 0);
        GameObject letterObj = Instantiate(letterPrefab, spawnPos, Quaternion.identity);
        letterObj.GetComponent<LetterBar>().letter = letter;

        nextIndex++;
    }
}
