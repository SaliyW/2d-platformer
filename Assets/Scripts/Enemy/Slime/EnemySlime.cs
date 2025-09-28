using UnityEngine;

[RequireComponent(typeof(EnemyCombatSlime))]
[RequireComponent(typeof(EnemyPatrol))]
[RequireComponent(typeof(EnemyDeadEndChecker))]
[RequireComponent(typeof(EnemyChaser))]
public class EnemySlime : Enemy
{
    private EnemyPatrol _patrol;
    private EnemyChaser _chaser;
    private EnemyPlayerDetector _playerDetector;

    protected override void Awake()
    {
        base.Awake();       
        _patrol = GetComponent<EnemyPatrol>();
        _chaser = GetComponent<EnemyChaser>();
        _playerDetector = GetComponentInChildren<EnemyPlayerDetector>();
    }

    private void Start()
    {
        _patrol.StartPatrol();       
    }

    private void LateUpdate()
    {
        _healthBar.LockRotation();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        _chaser.StartChasing += _patrol.StopPatrol;
        _chaser.StopChasing += _patrol.StartPatrol;
        _playerDetector.PlayerTriggerEntered += _chaser.StartChase;
        _playerDetector.PlayerTriggerExited += _chaser.StopChase;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        _chaser.StartChasing -= _patrol.StopPatrol;
        _chaser.StopChasing -= _patrol.StartPatrol;
        _playerDetector.PlayerTriggerEntered -= _chaser.StartChase;
        _playerDetector.PlayerTriggerExited -= _chaser.StopChase;
    }
}