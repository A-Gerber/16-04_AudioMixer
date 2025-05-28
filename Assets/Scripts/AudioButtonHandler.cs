using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class AudioButtonHandler : MonoBehaviour
{
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private AudioSource _audioSource;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(PlayClip);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(PlayClip);
    }

    public void PlayClip()
    {
        _audioSource.PlayOneShot(_audioClip);
    }
}