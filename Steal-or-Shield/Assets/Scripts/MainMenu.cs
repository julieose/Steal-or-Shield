using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // ��� �����, �� ������� ����� ������� 
    public string nextSceneName="Call0";
    public void PlayGame()
    {
        SceneManager.LoadScene(nextSceneName);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Exitgame()
    {
        Debug.Log("The game is closed");
        Application.Quit();
    }
}
