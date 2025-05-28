using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeRegulator : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixer;
    [SerializeField] private Slider _slider;
    [SerializeField] private string _exposedParameters;

    private void Awake()
    {
        _slider.onValueChanged.AddListener(SetVolume);
    }

    private void SetVolume(float value)
    {
        _mixer.audioMixer.SetFloat(_exposedParameters, VolumeConverter.ÑonvertValue(value));
    }
}