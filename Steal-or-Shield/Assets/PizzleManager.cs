using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleManager : MonoBehaviour
{
    public GameObject myGameObject;//������ ����� �������� ����
    public AudioClip bcgMusic;// ������ ������
    private GameObject[] puzzle;
    public static bool isCorrect;

    private void Start()
    {
        puzzle = GameObject.FindGameObjectsWithTag("Puzzle");
        CheckPuzzle();
    }

    private void Update()
    {
        CheckPuzzle();
    }

    private void CheckPuzzle()
    {
        bool allTrue = true;
        foreach (var item in puzzle)
        {
            float zRot = item.transform.rotation.eulerAngles.z;
            // ����������� ���� � �������� 0-360
            if (Mathf.Abs(Mathf.DeltaAngle(zRot, 0)) > 1f)
            {
                allTrue = false;
                break;
            }
        }
        if (allTrue && !isCorrect)
        {
            isCorrect = true;
            Debug.Log("YOU WIN");
            StartCoroutine(WinSequence());
        }
    }


    //IEnumerator Pause(float time)
    //{ 
    //    myGameObject.SetActive(true);
    //    //AudioSource audioSource = gameObject.GetComponent<AudioSource>();//��������� ��������� � �������
    //    //if (audioSource.isPlaying)
    //    //{
    //    //    audioSource.Pause();//������ �� ����� ������� ������
    //    //}
    //    //AudioSource.PlayClipAtPoint(bcgMusic, transform.position);
    //    Cursor.visible = false; //������ �� �����
    //    // ���������� ������ � �������


    //    // ���� 7 ������
    //    yield return new WaitForSecondsRealtime(time);

    //    // ������������ ������ � �������
    //    myGameObject.SetActive(false);


    //    Cursor.visible = true;//������� ������
    //    //audioSource.Play();//������� ������� ������
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    //}
    //IEnumerator Pause1(float time)
    //{

    //    // ���� 7 ������
    //    yield return new WaitForSecondsRealtime(time);

    //    StartCoroutine(Pause(5));

    //}

    //IEnumerator WinSequence()
    //{

    //    // ���������� ������ � �������
    //    myGameObject.SetActive(true);
    //    AudioSource audioSource = gameObject.GetComponent<AudioSource>();//��������� ��������� � �������
    //    if (audioSource.isPlaying)
    //    {
    //        audioSource.Pause();//������ �� ����� ������� ������
    //    }
    //    AudioSource.PlayClipAtPoint(bcgMusic, transform.position);

    //    // ��� 5 �������
    //    yield return new WaitForSecondsRealtime(5);

    //    // ������������ ������ � �������
    //    myGameObject.SetActive(false);

    //    // ��������� �� ��������� �����
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    //}

    IEnumerator WinSequence()
    {
        // ���������� ������ � �������
        myGameObject.SetActive(true);

        // ������ �� ����� ������� ������
        AudioSource audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Pause();
        }

        // ����������� �������� ������
        AudioSource.PlayClipAtPoint(bcgMusic, transform.position);

        // ��� 5 ������
        yield return new WaitForSecondsRealtime(5);

        // ������������ ������ � �������
        myGameObject.SetActive(false);

        // ��������� �� ��������� �����
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        int scena = Random.Range(1, 4);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + scena);
    }
}
