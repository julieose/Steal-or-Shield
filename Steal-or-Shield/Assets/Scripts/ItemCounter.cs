using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ItemCounter : MonoBehaviour
{
    public int totalItemsToFind = 10;// ���������� ���������, ������� ���������� �����

    // ������� ���������� ��������� ���������
    private int foundItemsCount = 0;

    // ��� �����, �� ������� ����� ������� ����� ����� ���� ���������
    public string nextSceneName;

    void Start()
    {
        // ��������, ��� �������� totalItemsToFind ���������
        if (totalItemsToFind <= 0)
        {
            //Debug.LogError("���������� ��������� ������ ���� ������ ����!");
            return;
        }
    }

    private IEnumerator PauseAndContinue()
    {
        // ����� �� 5 �������
        yield return new WaitForSeconds(5);
    }
    // �����, ���������� ��� ����������� ��������
    public void OnItemFound()
    {
        foundItemsCount++;

        // ���������, ����� �� �� ��� ��������
        if (foundItemsCount >= totalItemsToFind)
        {
            PauseAndContinue();
            SceneManager.LoadScene(nextSceneName);
        }
    }
}