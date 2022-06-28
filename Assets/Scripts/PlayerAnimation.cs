using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PlayerAnimation : MonoBehaviour
{
    private static readonly int Speed = Animator.StringToHash("Speed");
    
    private SpriteRenderer _sprite;
    private Animator _animator;
    private PlayerMovement _playerMovement;
    
    private void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        _sprite.flipX = Input.GetAxis("Horizontal") < 0;
        _animator.SetFloat(Speed, Mathf.Abs(_playerMovement.Velocity));
    }
}