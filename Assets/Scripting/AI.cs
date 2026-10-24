using UnityEngine;

public class AI : MonoBehaviour
{
    public float speed = 3f;
    public GameObject ball;
    private Vector2 ballPos;
    private Vector2 startPos;
    private float move;

    public Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
    }

    private void Update()
    {
        ballPos = ball.transform.position;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (ballPos.y > transform.position.y)
        {
            move = 1f;
        }
        else if (ballPos.y < transform.position.y)
        {
            move = -1f;
        }
        else
        {
            move = 0f;
        }

        rb.linearVelocityY = move * speed;
    }

    public void ResetPosition()
    {
        rb.linearVelocity = Vector2.zero;
        transform.position = startPos;
    }
}