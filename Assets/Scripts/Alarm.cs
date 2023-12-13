using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    private const float MinValueSound = 0.0f;
    private const float MaxValueSound = 1.0f;

    [SerializeField] private AudioSource _alarmSound;
    [SerializeField] private float _fadeTime;


    public void ActivateAlarm()
    {
        StartCoroutine(FadeAlarm(MaxValueSound));
    }

    public void DeactivateAlarm()
    {
        StartCoroutine(FadeAlarm(MinValueSound));
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