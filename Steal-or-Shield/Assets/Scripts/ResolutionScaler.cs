using UnityEngine;

public class ResolutionScaler : MonoBehaviour
{
    private float originalWidth = 1920f;  // �������� ������ ������
    private float originalHeight = 1080f; // �������� ������ ������

    void Update()
    {
        AdjustCameraAspectRatio();
    }

    void AdjustCameraAspectRatio()
    {
        float currentAspect = (float)Screen.width / Screen.height;
        float targetAspect = originalWidth / originalHeight;

        // ��������� ��������� ������� ��� ��������������� ������
        Camera.main.aspect = targetAspect;
    }
}