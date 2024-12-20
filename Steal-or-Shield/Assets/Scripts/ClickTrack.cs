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
            // ��������� ������ ����
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

    IEnumerator Wait5Sec()//�����
    {
        AudioSource audioSource = gameObject.GetComponent<AudioSource>();//��������� ��������� � �������
        if (audioSource.isPlaying)
        {
            audioSource.Pause();//������ �� ����� ������� ������
        }
        AudioSource.PlayClipAtPoint(bcgMusic, transform.position);
        Cursor.visible = false; //������ �� �����
        LockMouse(true);//�������� ����
        myGameObject.SetActive(true);//����� �������� ������ �� �������
        yield return new WaitForSecondsRealtime(5.0f);//���� 5 ������
        myGameObject.SetActive(false);//����� ���������� ������ �� �������
        Cursor.visible = true;//������� ������
        audioSource.Play();//������� ������� ������
        LockMouse(false);//����������� ����
    }
}