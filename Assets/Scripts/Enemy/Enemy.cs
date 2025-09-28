using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PolygonCollider2D))]
[RequireComponent(typeof(EnemyHealth))]
[RequireComponent(typeof(EnemyCollisionDetector))]
[RequireComponent(typeof(EnemyCombat))]
public class Enemy : MonoBehaviour
{
    [SerializeField] protected BarSlider _healthBar;

    protected EnemyHealth _health;
    protected EnemyCollisionDetector _collisionDetector;
    protected EnemyCombat _combat;

    protected virtual void Awake()
    {
        _health = GetComponent<EnemyHealth>();
        _collisionDetector = GetComponent<EnemyCollisionDetector>();
        _combat = GetComponent<EnemyCombat>();
    }

    protected virtual void OnEnable()
    {
        _health.CurrentValueChanged += _healthBar.DisplayChangedValue;
        _collisionDetector.PlayerCollisionEntered += _combat.TryAttackPlayer;
    }

    protected virtual void OnDisable()
    {
        _health.CurrentValueChanged -= _healthBar.DisplayChangedValue;
        _collisionDetector.PlayerCollisionEntered -= _combat.TryAttackPlayer;
    }
}