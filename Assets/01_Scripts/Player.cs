using UnityEngine;

[AutoInjectionTarget]
public class Player : MonoBehaviour, ISceneInstance<Player>
{
    [SerializeField, ComponentField]
    private Rigidbody2D _rigidbody;
    
    private float _moveSpeed = 3f;

    private void Start()
    {
        ((ISceneInstance<Player>)this).InitSceneInstance();
    }
    private void Update()
    {
        float dir = Input.GetAxisRaw("Horizontal");
        _rigidbody.linearVelocityX = dir * _moveSpeed;
    }
}
