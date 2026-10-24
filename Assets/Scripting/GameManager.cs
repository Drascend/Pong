using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player1;
    public GameObject Goal1;
    public GameObject Player1Text;

    public GameObject player2;
    public GameObject Goal2;
    public GameObject Player2Text;

    public GameObject ball;

    public bool isAIEnabled;
    public float maxScore = 5;

    private AsyncOperation load;

    private int player1Score;
    private int player2Score;

    private void Start()
    {
        player1Score = 0;
        player2Score = 0;
        PreloadScene();
    }

    public void Player1Scored()
    {
        player1Score++;
        Player1Text.GetComponent<UnityEngine.UI.Text>().text = player1Score.ToString();
        ResetPosition();
    }

    public void Player2Scored()
    {
        player2Score++;
        Player2Text.GetComponent<UnityEngine.UI.Text>().text = player2Score.ToString();
        ResetPosition();
    }

    private void ResetPosition()
    {
        if (isAIEnabled)
        {
            player2.GetComponent<AI>().ResetPosition();
        }
        else
        {
            player2.GetComponent<Players>().ResetPosition();
        }
        player1.GetComponent<Players>().ResetPosition();
        ball.GetComponent<BallMovement>().ResetPosition();
    }

    private void Update()
    {
        CheckScore();
    }

    private void CheckScore()
    {
        if (player1Score >= maxScore)
        {
            ActivateScene();
        }
        else if (player2Score >= maxScore)
        {
            ActivateScene();
        }
    }

    private void PreloadScene()
    {
        load = SceneManager.LoadSceneAsync("WinScreen");
        load.allowSceneActivation = false;
    }

    private void ActivateScene()
    {
        load.allowSceneActivation = true;
        load = null;
    }
}