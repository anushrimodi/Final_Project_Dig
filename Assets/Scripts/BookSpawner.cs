using UnityEngine;

public class BookSpawner : MonoBehaviour
{
    [Header("Prefab & Timing")]
    public GameObject BookObstacle;    // assign your BookObstacle/PipePair prefab
    public float spawnInterval = 1.6f;

    [Header("Vertical randomization")]
    public float minCenterY = -1.5f;     // center of gap range
    public float maxCenterY =  2.0f;

    float timer;

    void Update()
    {
        // if the game is paused, don't spawn
        if (Time.timeScale == 0f) return;

        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            timer = 0f;
            SpawnOne();
        }
    }

    void SpawnOne()
    {
        float y = Random.Range(minCenterY, maxCenterY);
        Vector3 pos = new Vector3(transform.position.x, y, 0f);
        Instantiate(BookObstacle, pos, Quaternion.identity);
    }
}
