using System;
using UnityEngine;

public class EnemyPlayerDetector : MonoBehaviour
{
    public Action<Transform> PlayerTriggerEntered;
    public Action PlayerTriggerExited;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            PlayerTriggerEntered?.Invoke(collision.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            PlayerTriggerExited?.Invoke();
        }
    }
}