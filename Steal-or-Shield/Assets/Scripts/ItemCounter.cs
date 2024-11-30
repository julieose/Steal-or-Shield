using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ItemCounter : MonoBehaviour
{
    public int totalItemsToFind = 10;// Количество предметов, которое необходимо найти

    // Текущее количество найденных предметов
    private int foundItemsCount = 0;

    // Имя сцены, на которую нужно перейти после сбора всех предметов
    public string nextSceneName;

    void Start()
    {
        // Убедимся, что значение totalItemsToFind корректно
        if (totalItemsToFind <= 0)
        {
            //Debug.LogError("Количество предметов должно быть больше нуля!");
            return;
        }
    }

    private IEnumerator PauseAndContinue()
    {
        // Пауза на 5 секунды
        yield return new WaitForSeconds(5);
    }
    // Метод, вызываемый при обнаружении предмета
    public void OnItemFound()
    {
        foundItemsCount++;

        // Проверяем, нашли ли мы все предметы
        if (foundItemsCount >= totalItemsToFind)
        {
            PauseAndContinue();
            SceneManager.LoadScene(nextSceneName);
        }
    }
}