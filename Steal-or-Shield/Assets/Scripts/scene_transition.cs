using UnityEngine;
using UnityEngine.SceneManagement;

public class scene_transition : MonoBehaviour
{
    public void Transition()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}