using UnityEngine;
using UnityEngine.SceneManagement;

public class SlideBehavior : MonoBehaviour
{
    public void Transition()
    {
        SceneManager.LoadScene("Action2");
    }

    public void Transition2()
    {
        SceneManager.LoadScene("bedroom");
    }
}