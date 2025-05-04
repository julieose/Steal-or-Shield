using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class light : MonoBehaviour
{
    public Image flashImage;
    public float flashDuration = 0.2f;

    void Start()
    {
        flashImage.color = new Color(1, 1, 1, 0); // прозрачный
    }

    public void TriggerFlash()
    {
        StartCoroutine(DoFlash());
    }

    IEnumerator DoFlash()
    {
        flashImage.color = new Color(1, 1, 1, 1); // белая вспышка
        yield return new WaitForSeconds(flashDuration);
        flashImage.color = new Color(1, 1, 1, 0); // обратно в прозрачный
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Например, по пробелу
        {
            flashEffect.TriggerFlash();
        }
    }
}
