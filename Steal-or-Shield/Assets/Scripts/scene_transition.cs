using UnityEngine;
using UnityEngine.SceneManagement;

public class scene_transition : MonoBehaviour
{
    public string SceneName;
    public void Transition()
    {
        SceneManager.LoadScene(SceneName);
    }
}