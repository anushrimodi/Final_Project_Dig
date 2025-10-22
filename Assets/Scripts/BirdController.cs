using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BirdController : MonoBehaviour
{
    [Header("Flap Settings")]
    public float flapForce = 7.5f;   // tweak 6–9 until it feels right
    public float maxUpVelocity = 8f; // clamps vertical burst

    Rigidbody2D rb;

    void Awake() => rb = GetComponent<Rigidbody2D>();

    void Update()
    {
        // Space, left mouse, or tap
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            Flap();
    }

    void Flap()
    {
        // zero out downward speed so the flap feels crisp
        rb.linearVelocity = new Vector2(rb.linearVelocityX, 0f);
        rb.AddForce(Vector2.up * flapForce, ForceMode2D.Impulse);

        // optional clamp
        if (rb.linearVelocityY > maxUpVelocity)
            rb.linearVelocity = new Vector2(rb.linearVelocityX, maxUpVelocity);
    }
}
