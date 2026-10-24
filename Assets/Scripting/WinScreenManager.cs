using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class WinScreenManager : MonoBehaviour
{
    public Text winnerText;

    private void Start()
    {
        StartCoroutine(HandleWinSequence());
    }

    private IEnumerator HandleWinSequence()
    {
        int winner = PlayerPrefs.GetInt("Winner", 0);
        bool isAIEnabled = PlayerPrefs.GetInt("IsAIEnabled", 0) == 1;

        if (winner == 1)
        {
            winnerText.text = "Player 1 Wins!";
        }
        else if (winner == 2)
        {
            if (isAIEnabled)
            {
                winnerText.text = "AI player wins!";
            }
            else
            {
                winnerText.text = "Player 2 Wins!";
            }
        }
        else
        {
            winnerText.text = "Winner Unknown";
        }

        yield return new WaitForSeconds(5f);

        SceneManager.LoadScene("MainMenu");
    }
}
