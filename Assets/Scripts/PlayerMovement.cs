using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float minX = -7f;
    public float maxX = 7f;

    public float basePaddleSpeed = 6f;
    public float speedMultiplier = 1f;

    private Rigidbody2D ballRb;
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;

        GameObject ball = GameObject.FindGameObjectWithTag("Ball");

        if (ball != null)
        {
            ballRb = ball.GetComponent<Rigidbody2D>();
        }
    }

    void Update()
    {
        float movementHorizontal = Input.GetAxis("Horizontal");

        float currentPaddleSpeed = basePaddleSpeed;

        if (ballRb != null)
        {
            float ballSpeed = ballRb.linearVelocity.magnitude;
            currentPaddleSpeed = ballSpeed * speedMultiplier;
        }

        transform.position += Vector3.right *
                              movementHorizontal *
                              currentPaddleSpeed *
                              Time.deltaTime;

        float clampedX = Mathf.Clamp(
            transform.position.x,
            minX,
            maxX
        );

        transform.position = new Vector3(
            clampedX,
            transform.position.y,
            transform.position.z
        );
    }

    public void ResetPaddle()
    {
        transform.position = startPosition;
    }
}