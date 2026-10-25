using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    private void OnEnable()
    {
        var document = GetComponent<UIDocument>();
        if (document == null) return;

        var root = document.rootVisualElement;

        var twoPlayersButton = root.Q<Button>("TwoPlayersButton");
        if (twoPlayersButton != null)
        {
            twoPlayersButton.RegisterCallback<ClickEvent>(evt => LoadTwoPlayerGame());
        }

        var singlePlayerButton = root.Q<Button>("SinglePlayerButton");
        if (singlePlayerButton != null)
        {
            singlePlayerButton.RegisterCallback<ClickEvent>(evt => LoadSinglePlayerGame());
        }
    }

    public void LoadTwoPlayerGame()
    {
        SceneManager.LoadScene("2_Player_Game");
    }

    public void LoadSinglePlayerGame()
    {
        SceneManager.LoadScene("Single_Player_Game");
    }
}
