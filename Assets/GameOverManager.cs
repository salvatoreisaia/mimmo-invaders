using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{

    public void OnApplicationQuit()
    {
        Debug.Log("Application Quit");
        Application.Quit();
    }
    public void Retry()
    {
        GameObject.FindGameObjectsWithTag("GameManager")[0].GetComponent<GameManager>().isGameOver = false;
        SceneManager.LoadScene("Main scene", LoadSceneMode.Single);
    }
}
