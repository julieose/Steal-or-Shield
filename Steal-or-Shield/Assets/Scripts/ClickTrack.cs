using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using static UnityEngine.RuleTile.TilingRuleOutput;
using UnityEngine.Audio;

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
            // ќбработка щелчка мыши
            //Debug.Log("Mouse clicked!");


            if (Input.GetKeyDown(MouseClick))
            {
                TotalClick += 1;
            }

            if (TotalClick >= 5)
            {
              
                TotalClick = 0;
                StartCoroutine(Wait5Sec());
            }
        }
    }

    IEnumerator Wait5Sec()//штраф
    {
        AudioSource audioSource = gameObject.GetComponent<AudioSource>();//определ€ю компонент с музыкой
        if (audioSource.isPlaying)
        {
            audioSource.Pause();//ставлю на паузу фоновую музыку
        }
        AudioSource.PlayClipAtPoint(bcgMusic, transform.position);
        Cursor.visible = false; //курсор не видно
        LockMouse(true);//блокирую мышь
        myGameObject.SetActive(true);//делаю активным объект со штрафом
        yield return new WaitForSecondsRealtime(5.0f);//ждет 5 секунд
        myGameObject.SetActive(false);//делаю неактивным объект со штрафом
        Cursor.visible = true;//включаю курсор
        audioSource.Play();//включаю фоновую музыку
        LockMouse(false);//разблокирую мышь
    }
}