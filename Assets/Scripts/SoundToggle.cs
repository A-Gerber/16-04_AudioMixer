using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class SoundToggle : MonoBehaviour
{
    private Toggle _toggle;

    private float _valueMute = 0f;
    private float _valueWithSound = 1f;

    private void Awake()
    {
        _toggle = GetComponent<Toggle>(); 
    }

    private void OnEnable()
    {
        _toggle.onValueChanged.AddListener(ToggleSound);
    }

    private void OnDisable()
    {
        _toggle.onValueChanged.RemoveListener(ToggleSound);
    }

    private void ToggleSound(bool isDisabled)
    {
        if (isDisabled)
        {
            AudioListener.volume = _valueMute;
        }
        else
        {
            AudioListener.volume = _valueWithSound;
        }
    }
}