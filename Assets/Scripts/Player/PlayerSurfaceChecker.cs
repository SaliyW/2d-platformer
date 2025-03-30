using UnityEngine;

public class PlayerSurfaceChecker : MonoBehaviour
{
    [SerializeField] private Vector2 _wallAheadSize = new(0.2f, 2f);
    [SerializeField] private Vector3 _wallAheadCastDistance = new(0.5f, -0.92f, 0);
    [SerializeField] private Vector2 _groundSize = new(1.3f, 0.3f);
    [SerializeField] private float _groundCastDistance = 2;
    [SerializeField] private LayerMask _surfaceLayer;

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position + _wallAheadCastDistance, _wallAheadSize);
        Gizmos.DrawWireCube(transform.position - transform.up * _groundCastDistance, _groundSize);
    }

    public bool IsWallAhead()
    {
        return Physics2D.BoxCast(transform.position + Vector3.up * _wallAheadCastDistance.y, _wallAheadSize, 0, transform.right, _wallAheadCastDistance.x, _surfaceLayer);
    }

    public bool IsGrounded()
    {
        return Physics2D.BoxCast(transform.position, _groundSize, 0, -transform.up, _groundCastDistance, _surfaceLayer);
    }
}