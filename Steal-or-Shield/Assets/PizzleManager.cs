using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleManager : MonoBehaviour
{
    public GameObject myGameObject;//объект после победной игры
    public AudioClip bcgMusic;// музыка победы
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
            // Нормализуем угол в диапазон 0-360
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
    //    //AudioSource audioSource = gameObject.GetComponent<AudioSource>();//определяю компонент с музыкой
    //    //if (audioSource.isPlaying)
    //    //{
    //    //    audioSource.Pause();//ставлю на паузу фоновую музыку
    //    //}
    //    //AudioSource.PlayClipAtPoint(bcgMusic, transform.position);
    //    Cursor.visible = false; //курсор не видно
    //    // Активируем объект с победой


    //    // Ждем 7 секунд
    //    yield return new WaitForSecondsRealtime(time);

    //    // Деактивируем объект с победой
    //    myGameObject.SetActive(false);


    //    Cursor.visible = true;//включаю курсор
    //    //audioSource.Play();//включаю фоновую музыку
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    //}
    //IEnumerator Pause1(float time)
    //{

    //    // Ждем 7 секунд
    //    yield return new WaitForSecondsRealtime(time);

    //    StartCoroutine(Pause(5));

    //}

    //IEnumerator WinSequence()
    //{

    //    // Активируем объект с победой
    //    myGameObject.SetActive(true);
    //    AudioSource audioSource = gameObject.GetComponent<AudioSource>();//определяю компонент с музыкой
    //    if (audioSource.isPlaying)
    //    {
    //        audioSource.Pause();//ставлю на паузу фоновую музыку
    //    }
    //    AudioSource.PlayClipAtPoint(bcgMusic, transform.position);

    //    // Ждём 5 секунды
    //    yield return new WaitForSecondsRealtime(5);

    //    // Деактивируем объект с победой
    //    myGameObject.SetActive(false);

    //    // Переходим на следующую сцену
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    //}

    IEnumerator WinSequence()
    {
        // Активируем объект с победой
        myGameObject.SetActive(true);

        // Ставим на паузу фоновую музыку
        AudioSource audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Pause();
        }

        // Проигрываем победную музыку
        AudioSource.PlayClipAtPoint(bcgMusic, transform.position);

        // Ждём 5 секунд
        yield return new WaitForSecondsRealtime(5);

        // Деактивируем объект с победой
        myGameObject.SetActive(false);

        // Переходим на следующую сцену
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        int scena = Random.Range(1, 4);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + scena);
    }
}
