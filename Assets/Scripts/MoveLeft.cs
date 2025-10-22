using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 3f;
    public float destroyX = -12f;

    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.left);
        if (transform.position.x < destroyX) Destroy(gameObject);
    }
}