using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[AutoInjectionTarget]
public class Player : MonoBehaviour, ISceneInstance<Player>
{
    [SerializeField, ComponentField]
    private Rigidbody2D _rigidbody;

    private float _groundCheckRadius = 0.2f;
    private string _groundLayerName = "Ground";
    private LayerMask _groundLayer;

    private float _moveSpeed = 3f;
    private float _fallSpeed = 1f;
    private float _jumpPower = 10f;

    private float _moveInput;
    private bool _jumpInput;

    private void Start()
    {
        _groundLayer = LayerMask.GetMask(_groundLayerName);

        ((ISceneInstance<Player>)this).InitSceneInstance();
    }

    private void Update()
    {
        _moveInput = Input.GetAxisRaw("Horizontal");
        _jumpInput = Input.GetKey(KeyCode.Space);
    }

    private void FixedUpdate()
    {
        _rigidbody.linearVelocityY -= _fallSpeed;
        _rigidbody.linearVelocityX = _moveInput * _moveSpeed;

        if (_jumpInput && IsGrounded())
        {
            _rigidbody.linearVelocityY = _jumpPower;
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(transform.position, _groundCheckRadius, _groundLayer);
    }
}