using System;
using UnityEngine;

[RequireComponent(typeof(PlayerBag))]
public class PlayerCollisionDetector : MonoBehaviour
{
    public Action<GameObject> EnemyCollisionEntered;

    private PlayerBag _bag;

    private void Awake()
    {
        _bag = GetComponent<PlayerBag>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IComponent component))
        {
            component.Accept(_bag);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>())
        {
            EnemyCollisionEntered?.Invoke(collision.gameObject);
        }
    }
}