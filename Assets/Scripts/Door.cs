using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Alarm _alarm;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out _))
        {
            _alarm.ActivateAlarm();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Player>(out _))
        {
            _alarm.DeactivateAlarm();
        }
    }   
}
