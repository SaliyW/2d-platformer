using UnityEngine;

public class EnemyDeadEndChecker : MonoBehaviour
{
    [SerializeField] private Vector2 _groundAheadSize = new(1, 0.2f);
    [SerializeField] private Vector3 _groundAheadCastDistance = new(1.5f, -0.45f, 0);
    [SerializeField] private Vector2 _wallAheadSize = new(0.2f, 1f);
    [SerializeField] private Vector3 _wallAheadCastDistance = new(1.2f, 0.2f, 0);
    [SerializeField] private LayerMask _surfaceLayer;

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position + _groundAheadCastDistance, _groundAheadSize);
        Gizmos.DrawWireCube(transform.position + _wallAheadCastDistance, _wallAheadSize);
    }

    public void TryTurnAround()
    {
        int rotationAngle = 180;

        if (IsObstacleAhead())
        {
            _groundAheadCastDistance.x = -_groundAheadCastDistance.x;
            transform.Rotate(Vector3.up * rotationAngle);
        }
    }

    public bool IsObstacleAhead()
    {
        return IsWallAhead() || IsGroundAhead() != true;
    }

    public bool IsGroundAhead()
    {
        return Physics2D.BoxCast(transform.position + Vector3.right * _groundAheadCastDistance.x, _groundAheadSize, 0, transform.up, _groundAheadCastDistance.y, _surfaceLayer);
    }

    public bool IsWallAhead()
    {
        return Physics2D.BoxCast(transform.position + Vector3.up * _wallAheadCastDistance.y, _wallAheadSize, 0, transform.right, _wallAheadCastDistance.x, _surfaceLayer);
    }
}