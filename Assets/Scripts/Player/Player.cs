using UnityEngine;

[RequireComponent(typeof(PlayerInputReader))]
[RequireComponent(typeof(PlayerSurfaceChecker))]
[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(PlayerJumper))]
[RequireComponent(typeof(PlayerAnimations))]
[RequireComponent(typeof(PlayerCollisionDetector))]
[RequireComponent(typeof(PlayerCombat))]
[RequireComponent(typeof(PlayerHealth))]
[RequireComponent(typeof(PlayerBag))]
public class Player : MonoBehaviour
{
    private PlayerMover _mover;
    private PlayerJumper _jumper;
    private PlayerCombat _combat;
    private PlayerCollisionDetector _collisionDetector;

    private void Awake()
    {
        _mover = GetComponent<PlayerMover>();
        _jumper = GetComponent<PlayerJumper>();
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
        _collisionDetector.EnemyCollisionEntered += _combat.TryAttackEnemy;
    }

    private void OnDisable()
    {
        _collisionDetector.EnemyCollisionEntered -= _combat.TryAttackEnemy;
    }
}