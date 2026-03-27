using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameScene"); 
    }

    public void GoToCredit()
{
    SceneManager.LoadScene("EndCredit");
}

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}