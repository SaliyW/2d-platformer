using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public void TryAttackPlayer(Transform player)
    {
        Rigidbody2D playerRigidbody = player.GetComponent<Rigidbody2D>();
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        Vector2 force;
        float xForce = 20;
        float yForce = 20;
        float minVelocity = -0.01f;
        int damage = 40;

        if (playerRigidbody.velocity.y >= minVelocity)
        {
            playerHealth.TakeDamage(damage);

            if (player.position.x < transform.position.x)
            {
                xForce = -xForce;
            }

            force = new(xForce, yForce);

            playerRigidbody.AddForce(force, ForceMode2D.Impulse);
        }
    }
}