using UnityEngine;

public class ResolutionScaler : MonoBehaviour
{
    private float originalWidth = 1920f;  // Исходная ширина экрана
    private float originalHeight = 1080f; // Исходная высота экрана

    void Update()
    {
        AdjustCameraAspectRatio();
    }

    void AdjustCameraAspectRatio()
    {
        float currentAspect = (float)Screen.width / Screen.height;
        float targetAspect = originalWidth / originalHeight;

        // Применяем коррекцию аспекта для ортографической камеры
        Camera.main.aspect = targetAspect;
    }
}