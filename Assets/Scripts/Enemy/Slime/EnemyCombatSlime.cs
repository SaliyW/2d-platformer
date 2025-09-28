using UnityEngine;

public class EnemyCombatSlime : EnemyCombat
{
    public override void TryAttackPlayer(Transform player)
    {
        Rigidbody2D playerRigidbody = player.GetComponent<Rigidbody2D>();
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        Vector2 force;
        float minVelocity = -0.02f;

        if (playerRigidbody.velocity.y >= minVelocity)
        {
            playerHealth.TakeDamage(_damage);

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
        }
    }
}