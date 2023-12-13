using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    private const float MaxValueSound = 1.0f;
    private const float MinValueSound = 0.0f;

    [SerializeField] private AudioSource _alarmSound;
    [SerializeField] private float _fadeTime;

    private bool _isFadingIn = false;
    private bool _isFadingOut = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out _))
        {
            _isFadingIn = true;
            _isFadingOut = false;
            StartCoroutine(FadeAlarm());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Player>(out _))
        {
            _isFadingOut = true;
            _isFadingIn = false;
            StartCoroutine(FadeAlarm());
        }
    }

    private IEnumerator FadeAlarm()
    {
        while (_isFadingIn && _alarmSound.volume < MaxValueSound || _isFadingOut && _alarmSound.volume > MinValueSound)
        {
            if (_isFadingIn)
            {
                _alarmSound.volume = Mathf.MoveTowards(_alarmSound.volume, MaxValueSound, Time.deltaTime / _fadeTime);
            }
            else if (_isFadingOut)
            {
                _alarmSound.volume = Mathf.MoveTowards(_alarmSound.volume, MinValueSound, Time.deltaTime / _fadeTime);
            }

            yield return null;
        }
    }
}