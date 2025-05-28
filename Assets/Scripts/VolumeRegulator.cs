using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeRegulator : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixer;
    [SerializeField] private Slider _slider;
    [SerializeField] private string _exposedParameter;

    private static float MinValue = 0.0001f;
    private static float Coefficient = 20f;

    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(SetVolume);
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(SetVolume);
    }

    private void SetVolume(float value)
    {
        _mixer.audioMixer.SetFloat(_exposedParameter, Mathf.Log10(Mathf.Max(MinValue, value)) * Coefficient);
    }
}