using UnityEngine;

public class BouncyBall : MonoBehaviour
{
    public float minY = -6f;
    public float launchSpeed = 8f;

    private Rigidbody2D rb;
    private Vector3 startPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;

        LaunchBall();
    }

    void Update()
    {
        // Ball falls below screen
        if (transform.position.y < minY)
        {
            ResetBall();

            // Lose 1 life
            if (GameManager.instance != null)
            {
                GameManager.instance.LoseLife();
            }
        }
    }

    void ResetBall()
    {
        // Stop ball movement
        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;

        // Reset ball position
        transform.position = startPosition;

        // Reset paddle position
        PlayerMovement paddle = FindObjectOfType<PlayerMovement>();

        if (paddle != null)
        {
            paddle.ResetPaddle();
        }

        // Launch again
        LaunchBall();
    }

    void LaunchBall()
    {
        float randomX = Random.Range(-1f, 1f);

        Vector2 direction = new Vector2(randomX, 1f).normalized;

        rb.linearVelocity = direction * launchSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Ball hit: " + collision.gameObject.name);

        // Brick destroyed = +10 score
        if (collision.gameObject.CompareTag("Brick"))
        {
            Destroy(collision.gameObject);

            if (GameManager.instance != null)
            {
                GameManager.instance.AddScore(10);
            }
        }
    }
}