using System;
using UnityEngine;

public class EnemyPlayerDetector : MonoBehaviour
{
    public Action<GameObject> PlayerTriggerEntered;
    public Action PlayerTriggerExited;
    public Action<GameObject> PlayerCollisionEntered;

    private void OnCollisionEnter2D(Collision2D playerCollision)
    {
        PlayerCollisionEntered?.Invoke(playerCollision.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerBase>())
        {
            PlayerTriggerEntered?.Invoke(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerBase>())
        {
            PlayerTriggerExited?.Invoke();
        }
    }
}
