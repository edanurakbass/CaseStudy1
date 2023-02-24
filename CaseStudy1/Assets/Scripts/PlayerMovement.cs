using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float _speed;
    private Joystick _joystick;
    private Rigidbody _rb;
    private Vector3 _joystickDirection;

    private void Start()
    {
        _joystick = FindObjectOfType<DynamicJoystick>();
        _rb = GetComponent<Rigidbody>();
    }
   
    private void FixedUpdate()
    {
        Move();
    }
    void Move()
    {
        _joystickDirection = new Vector3(
            _joystick.Horizontal * _speed,
            _rb.velocity.y,
            _joystick.Vertical * _speed
            );

        if (_joystick.Direction != Vector2.zero)
        {
            transform.forward = _joystickDirection;
        }
        _rb.velocity = _joystickDirection;

    }
}
