using UnityEngine;

[RequireComponent(typeof(EnemyDeadEndChecker))]
public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private float _speed = 5;

    private EnemyDeadEndChecker _enemyDeadEndChecker;

    private void Awake()
    {
        _enemyDeadEndChecker = GetComponent<EnemyDeadEndChecker>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(_speed * Time.deltaTime * Vector2.right);
        _enemyDeadEndChecker.TryTurnAround();
    }
}