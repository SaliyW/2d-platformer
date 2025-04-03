using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EnemyDeadEndChecker))]
public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private float _speed = 2;

    private EnemyDeadEndChecker _deadEndChecker;
    private Coroutine _coroutine;

    private void Awake()
    {
        _deadEndChecker = GetComponent<EnemyDeadEndChecker>();
    }

    public void StartPatrol()
    {
        _coroutine = StartCoroutine(Patrol());
    }

    public void StopPatrol()
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