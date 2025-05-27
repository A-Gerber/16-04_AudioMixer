using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixer;
    [SerializeField] private Slider _slider;
    [SerializeField] private string _exposedParameters;

    private float _minValue = 0.0001f;
    private float _coefficient = 20f;

    private void Awake()
    {
        _slider.onValueChanged.AddListener(SetVolume);
    }

    private void SetVolume(float value)
    {
        _mixer.audioMixer.SetFloat(_exposedParameters, Mathf.Log10(Mathf.Max(_minValue, value)) * _coefficient);
    }
}