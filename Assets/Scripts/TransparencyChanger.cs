using DG.Tweening;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TransparencyChanger : MonoBehaviour
{
    [SerializeField] private Tilemap _houseBack;
    [SerializeField] private Tilemap _houseFront;
    
    [SerializeField] private float _duration;
    [SerializeField] [Range(0, 1f)] private float _insideTransparency;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent(out PlayerMovement playerMovement) == false) return;
        
        DOTween.ToAlpha(() => _houseBack.color, color => _houseBack.color = color,
            _insideTransparency, _duration);
        DOTween.ToAlpha(() => _houseFront.color, color => _houseFront.color = color,
            _insideTransparency, _duration);
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent(out PlayerMovement playerMovement) == false) return;
        
        DOTween.ToAlpha(() => _houseBack.color, color => _houseBack.color = color,
            1, _duration);
        DOTween.ToAlpha(() => _houseFront.color, color => _houseFront.color = color,
            1, _duration);
    }
}
