using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundToggle : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixer;
    [SerializeField] private string _exposedParameters;

    private Toggle _toggle;

    private float _standardValue = 0f;
    private float _minValueMixer = -80f;

    private float _currentValue;

    private void Awake()
    {
        _toggle = GetComponent<Toggle>();

        _currentValue = _standardValue;

        _toggle.onValueChanged.AddListener(ToggleSound);
    }

    private void ToggleSound(bool isDisabled)
    {

        if (isDisabled)
        {
            _mixer.audioMixer.SetFloat(_exposedParameters, _minValueMixer);

        }
        else
        {
            _mixer.audioMixer.SetFloat(_exposedParameters, _currentValue);
        }
    }
}