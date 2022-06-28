using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 2;

    private float _velocity;

    public float Velocity => _velocity;

    private void Update()
    {
        _velocity = Input.GetAxis("Horizontal") * Time.deltaTime * _speed;
        
        Vector2 direction = new Vector2(_velocity, 0);
        transform.Translate(direction, Space.World);
    }
}