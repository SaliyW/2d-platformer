using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EnemyDeadEndChecker))]
[RequireComponent(typeof(EnemyPlayerDetector))]
public class EnemyChaser : MonoBehaviour
{
    [SerializeField] private float _speed = 6;

    public Action StartChasing;
    public Action StopChasing;

    private EnemyDeadEndChecker _deadEndChecker;
    private EnemyPlayerDetector _playerDetector;
    private Coroutine _coroutine;

    private void Awake()
    {
        _deadEndChecker = GetComponent<EnemyDeadEndChecker>();
        _playerDetector = GetComponent<EnemyPlayerDetector>();
    }

    private void OnEnable()
    {
        _playerDetector.PlayerTriggerEntered += StartChase;
        _playerDetector.PlayerTriggerExited += StopChase;
    }

    private void OnDisable()
    {
        _playerDetector.PlayerTriggerEntered -= StartChase;
        _playerDetector.PlayerTriggerExited -= StopChase;
    }

    private void StartChase(GameObject player)
    {
        _coroutine = StartCoroutine(ChasePlayer(player));
        StartChasing?.Invoke();
    }

    private void StopChase()
    {
        StopCoroutine(_coroutine);
        StopChasing?.Invoke();
    }

    private IEnumerator ChasePlayer(GameObject player)
    {
        Vector2 target;
        WaitForEndOfFrame wait = new();

        while (_deadEndChecker.IsObstacleAhead() != true)
        {
            target = new(player.transform.position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, target, _speed * Time.deltaTime);

            yield return wait;
        }
    }
}