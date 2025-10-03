using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerInputReader))]
[RequireComponent(typeof(PlayerSurfaceChecker))]
[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(PlayerJumper))]
[RequireComponent(typeof(PlayerAnimations))]
[RequireComponent(typeof(PlayerCollisionDetector))]
[RequireComponent(typeof(PlayerCombat))]
[RequireComponent(typeof(PlayerHealth))]
[RequireComponent(typeof(PlayerBag))]
[RequireComponent(typeof(PlayerVampirism))]
public class Player : MonoBehaviour
{
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private VampirismBar _vampirismBar;
    
    private PlayerMover _mover;
    private PlayerJumper _jumper;
    private PlayerCombat _combat;
    private PlayerCollisionDetector _collisionDetector;
    private PlayerHealth _health;
    private PlayerVampirism _vampirism;
    private VampirismTargetFinder _vampirismFinder;

    private void Awake()
    {
        _mover = GetComponent<PlayerMover>();
        _jumper = GetComponent<PlayerJumper>();
        _combat = GetComponent<PlayerCombat>();
        _collisionDetector = GetComponent<PlayerCollisionDetector>();
        _health = GetComponent<PlayerHealth>();
        _vampirism = GetComponent<PlayerVampirism>();
        _vampirismFinder = GetComponentInChildren<VampirismTargetFinder>();
    }

    private void Update()
    {
        _mover.TryMove();
        _jumper.TryJump();
        _vampirism.TryVampirism();
    }

    private void LateUpdate()
    {
        _healthBar.LockRotation();
    }

    private void OnEnable()
    {
        _collisionDetector.EnemyCollisionEntered += _combat.TryAttackEnemy;
        _health.CurrentValueChanged += _healthBar.DisplayChangedValue;
        _vampirism.CurrentValueChanged += _vampirismBar.DisplayChangedValue;
        _vampirism.VampirismActivityChanged += _vampirismFinder.ChangeActivity;
    }

    private void OnDisable()
    {
        _collisionDetector.EnemyCollisionEntered -= _combat.TryAttackEnemy;
        _health.CurrentValueChanged -= _healthBar.DisplayChangedValue;
        _vampirism.CurrentValueChanged -= _vampirismBar.DisplayChangedValue;
        _vampirism.VampirismActivityChanged -= _vampirismFinder.ChangeActivity;
    }
}