using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    private const float MaxValueSound = 1.0f;
    private const float MinValueSound = 0.0f;

    [SerializeField] private AudioSource _alarmSound;
    [SerializeField] private float _fadeTime;

    private void Start()
    {
        _alarmSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out _))
            StartCoroutine(FadeInAlarm());
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Player>(out _))
            StartCoroutine(FadeOutAlarm());
    }

    private IEnumerator FadeInAlarm()
    {
        while (_alarmSound.volume < MaxValueSound)
        {
            _alarmSound.volume = Mathf.MoveTowards(_alarmSound.volume, MaxValueSound, Time.deltaTime / _fadeTime);

            yield return null;
        }
    }

    private IEnumerator FadeOutAlarm()
    {
        while (_alarmSound.volume > MinValueSound)
        {
            _alarmSound.volume = Mathf.MoveTowards(_alarmSound.volume, MinValueSound, Time.deltaTime / _fadeTime);

            yield return null;
        }
    }
}