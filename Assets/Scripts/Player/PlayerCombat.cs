using UnityEngine;

[RequireComponent(typeof(PlayerCollisionDetector))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerCombat : MonoBehaviour
{
    private PlayerCollisionDetector _collisionDetector;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _collisionDetector = GetComponent<PlayerCollisionDetector>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _collisionDetector.EnemyCollisionEntered += TryAttackEnemy;
    }

    private void OnDisable()
    {
        _collisionDetector.EnemyCollisionEntered -= TryAttackEnemy;
    }

    private void TryAttackEnemy(GameObject enemy)
    {
        float minVelocity = -0.01f;

        if (_rigidbody.velocity.y < minVelocity)
        {
            Destroy(enemy);
        }
    }
}