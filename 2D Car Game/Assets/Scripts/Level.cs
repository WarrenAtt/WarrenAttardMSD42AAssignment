using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] float delayInSeconds = 2f;

    IEnumerator WaitAndLoads()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("GameOver");
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("SimpleCarGame");
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoads());
    }

    public void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        print("quit");
        //works only as EXE programs
        Application.Quit();
    }
}
