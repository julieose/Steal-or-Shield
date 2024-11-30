using UnityEngine;
using TMPro; // Уберите, если используете стандартный текст
using UnityEngine.UI; // Добавьте, если используете стандартный UI текст
using System.Collections;

public class TypewriterEffect : MonoBehaviour
{
    public TextMeshProUGUI myText; // Для TextMeshPro. Если стандартный Text, используйте `Text`.
    public float typingSpeed = 0.05f; // Скорость появления символов
    public float delayBeforeStart; // Задержка перед началом (в секундах)

    private string fullText; // Полный текст, который нужно отобразить
    private string currentText = ""; // Временный текст, отображаемый на экране

    void Start()
    {
        // Сохраняем полный текст
        fullText = myText.text;
        myText.text = ""; // Очищаем текст, чтобы начать с пустого

        // Запускаем появление текста с задержкой
        StartCoroutine(StartTypingWithDelay());
    }

    IEnumerator StartTypingWithDelay()
    {
        // Ждём задержку перед стартом
        yield return new WaitForSeconds(delayBeforeStart);

        // Постепенно добавляем текст
        for (int i = 0; i < fullText.Length; i++)
        {
            currentText += fullText[i]; // Добавляем по одному символу
            myText.text = currentText; // Обновляем текст на экране
            yield return new WaitForSeconds(typingSpeed); // Пауза между символами
        }
    }
}

