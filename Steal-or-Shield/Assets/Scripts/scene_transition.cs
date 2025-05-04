//using UnityEditor.SearchService;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class scene_transition : MonoBehaviour
{
    public void Transition()
    {
        //SceneManager.LoadScene("bedroom");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void LoadRandomScene()
    {
        //string[] scenes = new string[3] { "bedroom", "bedroom1", "bedroom2" };
        //string randomSceneName = scenes[Random.Range(0, scenes.Length)];
        //SceneManager.LoadScene(randomSceneName);
        int scena = Random.Range(1, 4);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + scena);
    }
    public void Skip()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }
}