using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider bgmSlider;
    [SerializeField] private Slider seSlider;

    private void Start()
    {
        masterSlider.value = SoundManager.MasterVolume;
        bgmSlider.value = SoundManager.BGMVolume;
        seSlider.value = SoundManager.SEVolume;

        masterSlider.onValueChanged.AddListener(SetMasterVolume);
        bgmSlider.onValueChanged.AddListener(SetBGMVolume);
        seSlider.onValueChanged.AddListener(SetSEVolume);
    }

    private void SetMasterVolume(float value)
    {
        SoundManager.MasterVolume = value;
    }

    private void SetBGMVolume(float value)
    {
        SoundManager.BGMVolume = value;
    }

    private void SetSEVolume(float value)
    {
        SoundManager.SEVolume = value;
    }
}