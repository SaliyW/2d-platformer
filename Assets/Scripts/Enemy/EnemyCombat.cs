using UnityEngine;

[RequireComponent(typeof(EnemyPlayerDetector))] 
public class EnemyCombat : MonoBehaviour
{
    private EnemyPlayerDetector _playerDetector;

    private void Awake()
    {
        _playerDetector = GetComponent<EnemyPlayerDetector>();
    }

    private void OnEnable()
    {
        _playerDetector.PlayerCollisionEntered += TryAttackPlayer;
    }

    private void OnDisable()
    {
        _playerDetector.PlayerCollisionEntered -= TryAttackPlayer;
    }

    private void TryAttackPlayer(GameObject player)
    {
        Rigidbody2D playerRigidbody;
        Vector2 force;
        float xForce = 20;
        float yForce = 20;

        if (player.TryGetComponent(out PlayerHealth playerHealth))
        {
            playerRigidbody = player.GetComponent<Rigidbody2D>();

            if (playerRigidbody.velocity.y >= 0)
            {
                playerHealth.LoseLife();

                if (player.transform.position.x < transform.position.x)
                {
                    xForce = -xForce;
                }

                force = new(xForce, yForce);

                playerRigidbody.AddForce(force, ForceMode2D.Impulse);
            }
        }
    }
}