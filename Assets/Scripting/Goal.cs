using Unity.VisualScripting;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public bool isPlayer1Goal;
    public GameObject gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            GameManager manager = gameManager.GetComponent<GameManager>();

            if (isPlayer1Goal)
            {
                manager.Player2Scored();
            }
            else
            {
                manager.Player1Scored();
            }
        }
    }
}