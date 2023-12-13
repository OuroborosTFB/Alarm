using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    private const float MinValueSound = 0.0f;

    [SerializeField] private AudioSource _alarmSound;
    [SerializeField] private float _fadeTime;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out _))
        {
            StartCoroutine(FadeAlarm(1.0f));
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
    }
}