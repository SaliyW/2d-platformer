using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EnemyDeadEndChecker))]
[RequireComponent(typeof(EnemyChaser))]
public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private float _speed = 2;

    private EnemyDeadEndChecker _deadEndChecker;
    private EnemyChaser _chaser;
    private Coroutine _coroutine;

    private void Awake()
    {
        _deadEndChecker = GetComponent<EnemyDeadEndChecker>();
        _chaser = GetComponent<EnemyChaser>();
    }

    private void Start()
    {
        StartPatrol();
    }

    private void OnEnable()
    {
        _chaser.StartChasing += StopPatrol;
        _chaser.StopChasing += StartPatrol;
    }

    private void OnDisable()
    {
        _chaser.StartChasing -= StopPatrol;
        _chaser.StopChasing -= StartPatrol;
    }

    private void StartPatrol()
    {
        _coroutine = StartCoroutine(Patrol());
    }

    private void StopPatrol()
    {
        StopCoroutine(_coroutine);
    }

    private IEnumerator Patrol()
    {
        WaitForEndOfFrame wait = new();

        while (true)
        {
            _deadEndChecker.TryTurnAround();
            transform.Translate(_speed * Time.deltaTime * Vector2.right);

            yield return wait;
        }
    }
}