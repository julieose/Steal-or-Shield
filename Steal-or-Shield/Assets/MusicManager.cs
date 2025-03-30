using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Slider volumeSlider;          // �������� ��� ���������� ����������
    public AudioMixer audioMixer;        // ��� ������ ������

    void Start()
    {
        // �������� ����������� ���������
        if (PlayerPrefs.HasKey("volume"))
        {
            float savedVolume = PlayerPrefs.GetFloat("volume");
            volumeSlider.value = savedVolume;
            SetVolume(savedVolume);
        }
    }

    public void SetVolume(float volume)
    {
        // ������������� ��������� � �������
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
        // ��������� �������� ���������
        PlayerPrefs.SetFloat("volume", volume);
    }
}
