using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
using TMPro;

public class MenuManager : MonoBehaviour
{
    //!!!!public TextMeshProUGUI UserName;
    public TMP_Text BestScoreText;
    public TMP_InputField UserInputField;

    private void Start()
    {
        if (GameManager.gameData != null && BestScoreText != null)
        {
            BestScoreText.text = "Best Score: " + GameManager.gameData.highScore;
        }

        if (GameManager.gameData != null && UserInputField != null)
        {
            UserInputField.text = GameManager.gameData.playerName;
        }

    }

    public void StartNew()
    {
        GameManager.gameData.playerName = UserInputField.text;
        SceneManager.LoadScene("main");
    }

    public void StartMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
