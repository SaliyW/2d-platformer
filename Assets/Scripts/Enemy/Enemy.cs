using UnityEngine;

[RequireComponent(typeof(EnemyPatrol))]
[RequireComponent(typeof(EnemyDeadEndChecker))]
[RequireComponent(typeof(EnemyChaser))]
[RequireComponent(typeof(EnemyCombat))]
[RequireComponent(typeof(EnemyPlayerDetector))]
public class Enemy : MonoBehaviour
{
    private EnemyPatrol _patrol;
    private EnemyChaser _chaser;
    private EnemyCombat _combat;
    private EnemyPlayerDetector _playerDetector;

    private void Awake()
    {
        _patrol = GetComponent<EnemyPatrol>();
        _chaser = GetComponent<EnemyChaser>();
        _combat = GetComponent<EnemyCombat>();
        _playerDetector = GetComponent<EnemyPlayerDetector>();
    }

    private void Start()
    {
        _patrol.StartPatrol();
    }

    private void OnEnable()
    {
        _chaser.StartChasing += _patrol.StopPatrol;
        _chaser.StopChasing += _patrol.StartPatrol;
        _playerDetector.PlayerTriggerEntered += _chaser.StartChase;
        _playerDetector.PlayerTriggerExited += _chaser.StopChase;
        _playerDetector.PlayerCollisionEntered += _combat.TryAttackPlayer;
    }

    private void OnDisable()
    {
        _chaser.StartChasing -= _patrol.StopPatrol;
        _chaser.StopChasing -= _patrol.StartPatrol;
        _playerDetector.PlayerTriggerEntered -= _chaser.StartChase;
        _playerDetector.PlayerTriggerExited -= _chaser.StopChase;
        _playerDetector.PlayerCollisionEntered -= _combat.TryAttackPlayer;
    }
}