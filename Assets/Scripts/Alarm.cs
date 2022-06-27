using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private int _alarmRiseTime = 3;
    
    private AudioSource _audioSource;
    private Sequence _sequence;

    public void SetActiveAlarm(bool isActive)
    {
        if (isActive)
        {
            _sequence.Kill();
            _audioSource.Play();
            _audioSource.DOFade(1, _alarmRiseTime);
        }
        else
        {
            _sequence = DOTween.Sequence()
                .Append(_audioSource.DOFade(0, _alarmRiseTime))
                .AppendCallback(() => _audioSource.Stop());
        }
    }
    
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
}
