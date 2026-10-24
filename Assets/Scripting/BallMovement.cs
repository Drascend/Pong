using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float initialSpeed = 6f;
    public float speedIncreaseFactor = 1.01f;
    public Rigidbody2D rb;
    private Vector2 startPos;
    [SerializeField] private float speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
        Launch();
    }

    public void Launch()
    {
        speed = initialSpeed;
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        Vector2 direction = new Vector2(x, y).normalized;
        rb.linearVelocity = direction * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            speed *= speedIncreaseFactor;
            rb.linearVelocity = rb.linearVelocity.normalized * speed;
        }

    }

    public void ResetPosition()
    {
        rb.linearVelocity = Vector2.zero;
        transform.position = startPos;
        Launch();
    }
}