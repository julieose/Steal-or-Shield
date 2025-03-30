using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Slider volumeSlider;          // Ползунок для управления громкостью
    public AudioMixer audioMixer;        // Ваш микшер звуков

    void Start()
    {
        // Загрузка сохраненной громкости
        if (PlayerPrefs.HasKey("volume"))
        {
            float savedVolume = PlayerPrefs.GetFloat("volume");
            volumeSlider.value = savedVolume;
            SetVolume(savedVolume);
        }
    }

    public void SetVolume(float volume)
    {
        // Устанавливаем громкость в микшере
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
        // Сохраняем значение громкости
        PlayerPrefs.SetFloat("volume", volume);
    }
}
