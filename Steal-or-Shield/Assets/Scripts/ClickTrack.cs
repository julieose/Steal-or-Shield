using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class ClickTrack : MonoBehaviour
{

    public static int TotalClick = 0;
    public KeyCode MouseClick;
    public AudioClip bcgMusic;
    public GameObject myGameObject;
    private bool isMouseLocked = false;

    void Start()
    {
        myGameObject.SetActive(false);
    }
    public void LockMouse(bool lockMouse)
    {
        isMouseLocked = lockMouse;
    }
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && !isMouseLocked)
        {
            // Обработка щелчка мыши
            //Debug.Log("Mouse clicked!");


            if (Input.GetKeyDown(MouseClick))
            {
                TotalClick += 1;
            }

            if (TotalClick >= 5)
            {
                TotalClick = 0;
               // AudioSource.PlayClipAtPoint(bcgMusic, transform.position);
                StartCoroutine(Wait5Sec());

            }
        }
    }

    IEnumerator Wait5Sec()
    {
        AudioSource.PlayClipAtPoint(bcgMusic, transform.position);
        Cursor.visible = false;
        LockMouse(true);
        myGameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(5.0f);
        myGameObject.SetActive(false);
        Cursor.visible = true;
        LockMouse(false);
    }
}