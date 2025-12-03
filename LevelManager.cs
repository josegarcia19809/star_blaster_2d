using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("GameScene");
        ScoreKeeper.GetInstance().ResetScore();
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoadScene("GameOverScene", 2f));
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

    public void LoadMenu()
    {
        StartCoroutine(WaitAndLoadScene("MainMenu", .02f));
    }

    IEnumerator WaitAndLoadScene(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}