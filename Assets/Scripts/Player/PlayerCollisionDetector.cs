using System;
using UnityEngine;

public class PlayerCollisionDetector : MonoBehaviour
{
    public Action<GameObject> GemTriggerEntered;
    public Action<GameObject> CherryTriggerEntered;
    public Action<GameObject> EnemyCollisionEntered;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Gem>())
        {
            GemTriggerEntered?.Invoke(collision.gameObject);
        }
        else if (collision.gameObject.GetComponent<Cherry>())
        {
            CherryTriggerEntered?.Invoke(collision.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyBase>())
        {
            EnemyCollisionEntered?.Invoke(collision.gameObject);
        }
    }
}