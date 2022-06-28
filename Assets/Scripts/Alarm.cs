using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private int _alarmRiseTime = 3;
    
    private readonly float _lowEndValue = 0;
    private readonly float _highEndValue = 1;
    
    private AudioSource _audioSource;
    private Sequence _sequence;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    
    public void SetActiveAlarm(bool isActive)
    {
        if (isActive)
        {
            _sequence.Kill();
            _audioSource.Play();
            _audioSource.DOFade(_highEndValue, _alarmRiseTime);
        }
        else
        {
            _sequence = DOTween.Sequence()
                .Append(_audioSource.DOFade(_lowEndValue, _alarmRiseTime))
                .AppendCallback(() => _audioSource.Stop());
        }
    }
}
