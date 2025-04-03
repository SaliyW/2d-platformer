using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EnemyDeadEndChecker))]
public class EnemyChaser : MonoBehaviour
{
    [SerializeField] private float _speed = 6;

    public Action StartChasing;
    public Action StopChasing;

    private EnemyDeadEndChecker _deadEndChecker;
    private Coroutine _coroutine;

    private void Awake()
    {
        _deadEndChecker = GetComponent<EnemyDeadEndChecker>();
    }

    public void StartChase(Transform player)
    {
        _coroutine = StartCoroutine(ChasePlayer(player));
        StartChasing?.Invoke();
    }

    public void StopChase()
    {
        StopCoroutine(_coroutine);
        StopChasing?.Invoke();
    }

    private IEnumerator ChasePlayer(Transform player)
    {
        Vector2 target;
        WaitForEndOfFrame wait = new();

        while (_deadEndChecker.IsObstacleAhead() != true)
        {
            target = new(player.position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, target, _speed * Time.deltaTime);

            yield return wait;
        }
    }
}