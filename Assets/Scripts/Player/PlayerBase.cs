using UnityEngine;

[RequireComponent(typeof(PlayerInputReader))]
[RequireComponent(typeof(PlayerSurfaceChecker))]
[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(PlayerJumper))]
[RequireComponent(typeof(PlayerAnimationsController))]
[RequireComponent(typeof(PlayerCollisionDetector))]
[RequireComponent(typeof(PlayerCombat))]
[RequireComponent(typeof(PlayerHealth))]
[RequireComponent(typeof(PlayerBag))]
public class PlayerBase : MonoBehaviour
{
    private PlayerMover _mover;
    private PlayerJumper _jumper;
    private PlayerHealth _health;
    private PlayerBag _bag;
    private PlayerCombat _combat;
    private PlayerCollisionDetector _collisionDetector;

    private void Awake()
    {
        _mover = GetComponent<PlayerMover>();
        _jumper = GetComponent<PlayerJumper>();
        _health = GetComponent<PlayerHealth>();
        _bag = GetComponent<PlayerBag>();
        _combat = GetComponent<PlayerCombat>();
        _collisionDetector = GetComponent<PlayerCollisionDetector>();
    }

    private void Update()
    {
        _mover.TryMove();
        _jumper.TryJump();
    }

    private void OnEnable()
    {
        _collisionDetector.CherryTriggerEntered += _health.Heal;
        _collisionDetector.GemTriggerEntered += _bag.TakeGem;
        _collisionDetector.EnemyCollisionEntered += _combat.TryAttackEnemy;
    }

    private void OnDisable()
    {
        _collisionDetector.CherryTriggerEntered -= _health.Heal;
        _collisionDetector.GemTriggerEntered -= _bag.TakeGem;
        _collisionDetector.EnemyCollisionEntered -= _combat.TryAttackEnemy;
    }
}