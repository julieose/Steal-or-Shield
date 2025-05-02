using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // ��� ������ � ��������� ����
using static UnityEngine.RuleTile.TilingRuleOutput;
using UnityEngine.Audio;

public class Timer: MonoBehaviour
{
    public float timeLeft = 20f;   // ����� �� ��������� ������� 
    public string nextSceneName = "Room2"; // ��������� �����
    public AudioClip bcgMusic;// ������ ��� ������������� �������
    public GameObject myGameObject;// ������ �������������

    [SerializeField]
    private TMPro.TextMeshProUGUI timerText; // ������ �� UI ������� ��� ����������� �������

    void Start()
    {
        myGameObject.SetActive(false);
        if (timerText == null)
            Debug.LogError("Timer text is not assigned!");


        UpdateTimerText();
    }

    void Update()
    {
        if (timeLeft > 0)
        {
            UpdateTimerText(); // ��������� ����� �������
            timeLeft -= Time.deltaTime; // ��������� ���������� �����
        }
        else
        {
            myGameObject.SetActive(true);
           // StartCoroutine(Wait5SecEnd());
            //SceneManager.LoadScene(nextSceneName); // ��������� ��������� �����
        }
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(timeLeft / 60);
        int seconds = Mathf.FloorToInt(timeLeft % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds); // ����������� �����
    }
    IEnumerator Wait5SecEnd()//��� �������������
    {
        //AudioSource audioSource = gameObject.GetComponent<AudioSource>();//��������� ��������� � �������
        //if (audioSource.isPlaying)
        //{
        //    audioSource.Pause();//������ �� ����� ������� ������
        //}
        //AudioSource.PlayClipAtPoint(bcgMusic, transform.position);
        //Cursor.visible = false; //������ �� �����
        //LockMouse(true);//�������� ����
        myGameObject.SetActive(true);//����� �������� ������ �� �������
        yield return new WaitForSecondsRealtime(5.0f);//���� 5 ������
        myGameObject.SetActive(false);//����� ���������� ������ �� �������
        //Cursor.visible = true;//������� ������
        //audioSource.Play();//������� ������� ������
        //LockMouse(false);//����������� ����
        SceneManager.LoadScene(nextSceneName); // ��������� ��������� �����
    }
}