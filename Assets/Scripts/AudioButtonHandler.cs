using UnityEngine;
using UnityEngine.UI;

public class AudioButtonHandler : MonoBehaviour
{
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private AudioSource _audioSource;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(PlayClip);
    }

    public void PlayClip()
    {
        _audioSource.PlayOneShot(_audioClip);
    }
}