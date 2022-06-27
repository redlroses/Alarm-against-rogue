using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private int _alarmRiseTime = 3;
    
    private AudioSource _audioSource;
    private Sequence _sequence;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent(out PlayerMovement playerMovement) == false) return;
        _sequence.Kill();
        _audioSource.Play();
        _audioSource.DOFade(1, _alarmRiseTime);
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent(out PlayerMovement playerMovement) == false) return;
        _sequence = DOTween.Sequence()
            .Append(_audioSource.DOFade(0, _alarmRiseTime))
            .AppendCallback(() => _audioSource.Stop());

    }
}
