using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    [SerializeField] private Vector2 _groundAheadSize = new(1, 0.2f);
    [SerializeField] private Vector3 _groundAheadCastDistance = new(2, -0.6f, 0);
    [SerializeField] private Vector2 _wallAheadSize = new(0.2f, 1f);
    [SerializeField] private Vector3 _wallAheadCastDistance = new(2, 0.2f, 0);
    [SerializeField] private LayerMask _surfaceLayer;

    private void Update()
    {
        Move();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position + _groundAheadCastDistance, _groundAheadSize);
        Gizmos.DrawWireCube(transform.position + _wallAheadCastDistance, _wallAheadSize);
    }

    private void Move()
    {
        transform.Translate(_speed * Time.deltaTime * Vector2.right);

        if (!IsGroundAhead() || IsWallAhead())
        {
            TurnAround();
        }
    }

    private void TurnAround()
    {
        _groundAheadCastDistance.x = -_groundAheadCastDistance.x;
        transform.Rotate(Vector3.up * 180);
    }

    private bool IsGroundAhead()
    {
        return Physics2D.BoxCast(transform.position + Vector3.right * _groundAheadCastDistance.x, _groundAheadSize, 0, transform.up, _groundAheadCastDistance.y, _surfaceLayer);
    }

    private bool IsWallAhead()
    {
        return Physics2D.BoxCast(transform.position + Vector3.up * _wallAheadCastDistance.y, _wallAheadSize, 0, transform.right, _wallAheadCastDistance.x, _surfaceLayer);
    }
}