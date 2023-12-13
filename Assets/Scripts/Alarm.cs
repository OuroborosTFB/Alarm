using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    private const float MinValueSound = 0.0f;
    private const float MaxValueSound = 1.0f;

    [SerializeField] private AudioSource _alarmSound;
    [SerializeField] private float _fadeTime;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out _))
        {
            StartCoroutine(FadeAlarm(MaxValueSound));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Player>(out _))
        {
            StartCoroutine(FadeAlarm(MinValueSound));
        }
    }

    private IEnumerator FadeAlarm(float targetVolume)
    {
        while (!Mathf.Approximately(_alarmSound.volume, targetVolume))
        {
            _alarmSound.volume = Mathf.MoveTowards(_alarmSound.volume, targetVolume, Time.deltaTime / _fadeTime);
            yield return null;
        }

        _alarmSound.volume = targetVolume;

        if (Mathf.Approximately(targetVolume, MinValueSound))
        {
            _alarmSound.Stop();
        }
    }
}