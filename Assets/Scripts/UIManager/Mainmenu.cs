using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene("Assets/Scenes/StartMenu.unity");
    }
}
