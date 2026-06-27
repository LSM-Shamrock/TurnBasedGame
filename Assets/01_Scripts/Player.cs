using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[AutoInjectionTarget]
public class Player : MonoBehaviour, ISceneInstance<Player>
{
    [SerializeField, ComponentField]
    private Rigidbody2D _rigidbody;
    [SerializeField, ChildField("GroundChecker")]
    private Collider2D _groundChecker;
    
    private float _moveSpeed = 3f;
    private float _fallSpeed = 1f;
    private float _jumpPower = 10f;

    private float _moveInput;
    private bool _jumpInput;
    private bool _isGround;

    private void Start()
    {
        ((ISceneInstance<Player>)this).InitSceneInstance();
    }
    private void Update()
    {
        _moveInput = Input.GetAxisRaw("Horizontal");
        _jumpInput = Input.GetKeyDown(KeyCode.Space);
    }
    private void FixedUpdate()
    {
        _rigidbody.linearVelocityY -= _fallSpeed;

        _rigidbody.linearVelocityX = _moveInput * _moveSpeed;

        _isGround = CheckGround();
        if (_isGround && _jumpInput)
            _rigidbody.linearVelocityY = _jumpPower;
    }

    private bool CheckGround()
    {
        return Physics2D.OverlapBox(_groundChecker.bounds.center, _groundChecker.bounds.size, _groundChecker.includeLayers);
    }
}
