using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void startGame()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void exitGame()
    {
        Application.Quit();
    }
}
