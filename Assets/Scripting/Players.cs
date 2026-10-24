using UnityEngine;
using UnityEngine.InputSystem;

public class Players : MonoBehaviour
{
    public bool isPlayer1;
    public float speed = 3f;
    public Rigidbody2D rb;

    private float move;
    private Vector2 startPos;

    [SerializeField] private InputActionAsset inputActions;
    private InputActionMap playerActionMap;
    private InputAction moveUp;
    private InputAction moveDown;

    private void Awake()
    {
        if (isPlayer1)
        {
            playerActionMap = InputSystem.actions.FindActionMap("Player1", true);
        }
        else
        {
            playerActionMap = InputSystem.actions.FindActionMap("Player2", true);
        }
    }

    private void OnEnable()
    {
        playerActionMap.Enable();
    }

    private void OnDisable()
    {
        playerActionMap.Disable();
    }

     private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;

        moveUp = playerActionMap.FindAction("Up");
        moveDown = playerActionMap.FindAction("Down");

    }

    private void Update()
    {
        CheckImput();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void CheckImput()
    {
        if (moveUp.ReadValue<float>() > 0)
        {
            move = 1f;
        }
        else if (moveDown.ReadValue<float>() > 0)
        {
            move = -1f;
        }
        else
        {
            move = 0f;
        }
    }

    private void Move()
    {
        rb.linearVelocityY = move * speed;
    }

    public void ResetPosition()
    {
        rb.linearVelocity = Vector2.zero;
        transform.position = startPos;
    }
}