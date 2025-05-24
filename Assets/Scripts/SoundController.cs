using UnityEngine;
using UnityEngine.Audio;

public class SoundController : MonoBehaviour
{
    private const string MasterVolume = "MasterVolume";
    private const string MusicVolume = "MusicVolume";
    private const string DoorLockVolume = "DoorLockVolume";
    private const string ScreamVolume = "ScreamVolume";
    private const string ShotVolume = "ShotVolume";

    [SerializeField] private AudioMixerGroup _mixer;

    private float _standardValue = 0f;
    private float _minValueMixer = -80f;
    private float _minValue = 0.0001f;

    private float _currentValueMaster;
    private float _currentValueMusic;
    private float _currentValueEffects;

    private void Awake()
    {
        _currentValueMaster = _standardValue;
        _currentValueMusic = _standardValue;
        _currentValueEffects = _standardValue;
    }

    public void ToggleSound(bool isDisabled)
    {
        if (isDisabled)
        {
            _mixer.audioMixer.SetFloat(MasterVolume, _minValueMixer);
        }
        else
        { 
            _mixer.audioMixer.SetFloat(MasterVolume, _currentValueMaster);
        }
    }

    public void ChangeVolumeMaster(float volume)
    {
        _currentValueMaster = Mathf.Log10(Mathf.Max(_minValue, volume)) * 20;

        _mixer.audioMixer.SetFloat(MasterVolume, _currentValueMaster);
    }

    public void ChangeVolumeMusic(float volume)
    {
        CalculateValue(out _currentValueMusic, volume);

        SetVolume(_currentValueMusic, MusicVolume);
    }

    public void ChangeVolumeEffects(float volume)
    {
        CalculateValue(out _currentValueEffects, volume);

        SetVolume(_currentValueEffects, DoorLockVolume);
        SetVolume(_currentValueEffects, ScreamVolume);
        SetVolume(_currentValueEffects, ShotVolume);
    }

    private void SetVolume(float value, string audioController)
    {
        _mixer.audioMixer.SetFloat(audioController, value);
    }

    private void CalculateValue(out float value, float volume)
    {
        value = Mathf.Log10(Mathf.Max(_minValue, volume)) * 20;
    }
}