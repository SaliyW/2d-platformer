using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    [SerializeField] protected int _damage = 40;
    [SerializeField] protected float _xForce = 20;
    [SerializeField] protected float _yForce = 20;

    public virtual void TryAttackPlayer(Transform player)
    {
        Rigidbody2D playerRigidbody = player.GetComponent<Rigidbody2D>();
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        Vector2 force;

        if (player.position.x < transform.position.x)
        {
            _xForce = -_xForce;
        }

        if (player.position.y < transform.position.y)
        {
            _yForce = -_yForce;
        }

        force = new(_xForce, _yForce);
        playerRigidbody.AddForce(force, ForceMode2D.Impulse);
        playerHealth.TakeDamage(_damage);
    }
}