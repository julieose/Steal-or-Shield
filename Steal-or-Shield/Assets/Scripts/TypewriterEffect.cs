using UnityEngine;
using TMPro; // �������, ���� ����������� ����������� �����
using UnityEngine.UI; // ��������, ���� ����������� ����������� UI �����
using System.Collections;

public class TypewriterEffect : MonoBehaviour
{
    public TextMeshProUGUI myText; // ��� TextMeshPro. ���� ����������� Text, ����������� `Text`.
    public float typingSpeed = 0.05f; // �������� ��������� ��������
    public float delayBeforeStart; // �������� ����� ������� (� ��������)

    private string fullText; // ������ �����, ������� ����� ����������
    private string currentText = ""; // ��������� �����, ������������ �� ������

    void Start()
    {
        // ��������� ������ �����
        fullText = myText.text;
        myText.text = ""; // ������� �����, ����� ������ � �������

        // ��������� ��������� ������ � ���������
        StartCoroutine(StartTypingWithDelay());
    }

    IEnumerator StartTypingWithDelay()
    {
        // ��� �������� ����� �������
        yield return new WaitForSeconds(delayBeforeStart);

        // ���������� ��������� �����
        for (int i = 0; i < fullText.Length; i++)
        {
            currentText += fullText[i]; // ��������� �� ������ �������
            myText.text = currentText; // ��������� ����� �� ������
            yield return new WaitForSeconds(typingSpeed); // ����� ����� ���������
        }
    }
}

