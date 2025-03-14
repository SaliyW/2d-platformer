using UnityEngine;

public class PlayerGroundChecker : MonoBehaviour
{
    [SerializeField] private Vector2 _boxSize = new(1.3f, 0.3f);
    [SerializeField] private float _castDistance = 2;
    [SerializeField] private LayerMask _groundLayer;

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position - transform.up * _castDistance, _boxSize);
    }

    public bool IsGrounded()
    {
        return Physics2D.BoxCast(transform.position, _boxSize, 0, -transform.up, _castDistance, _groundLayer);
    }
}