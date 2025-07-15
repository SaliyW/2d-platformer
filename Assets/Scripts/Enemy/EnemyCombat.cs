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

        if (playerRigidbody.velocity.y >= 0)
        {
            playerHealth.LoseHealth();

            if (player.position.x < transform.position.x)
            {
                xForce = -xForce;
            }

            force = new(xForce, yForce);

            playerRigidbody.AddForce(force, ForceMode2D.Impulse);
        }
    }
}