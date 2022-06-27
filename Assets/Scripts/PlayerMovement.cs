using System;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 2;
    
    private SpriteRenderer _sprite;
    private Animator _animator;
    private static readonly int Speed = Animator.StringToHash("Speed");

    private void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        float velocity = Input.GetAxis("Horizontal") * Time.deltaTime * _speed;
        
        Vector2 direction = new Vector2(velocity, 0);
        transform.Translate(direction, Space.World);

        _sprite.flipX = Input.GetAxis("Horizontal") < 0;
        
        _animator.SetFloat(Speed, Mathf.Abs(velocity));
    }
}

