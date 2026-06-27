using UnityEngine;

[AutoInjectionTarget]
public class CameraController : MonoBehaviour
{
    [SerializeField, ChildField("DeadZone")]
    private BoxCollider2D _deadZone;


    private float _moveSpeedX = 2f;
    private float _moveSpeedY = 1f;

    private void FixedUpdate()
    {
        Vector2 playerPos = ISceneInstance<Player>.SceneInstance.transform.position;
        Vector3 targetPos = transform.position;
        Bounds bounds = _deadZone.bounds;

        if (playerPos.x < bounds.min.x) targetPos.x += playerPos.x - bounds.min.x;
        if (playerPos.x > bounds.max.x) targetPos.x += playerPos.x - bounds.max.x;
        if (playerPos.y < bounds.min.y) targetPos.y += playerPos.y - bounds.min.y;
        if (playerPos.y > bounds.max.y) targetPos.y += playerPos.y - bounds.max.y;

        Vector3 pos = transform.position;
        pos.x = Mathf.Lerp(pos.x, targetPos.x, _moveSpeedX * Time.fixedDeltaTime);
        pos.y = Mathf.Lerp(pos.y, targetPos.y, _moveSpeedY * Time.fixedDeltaTime);
        transform.position = pos;
    }
}
