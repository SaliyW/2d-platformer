using System;
using UnityEngine;

public class EnemyCollisionDetector : MonoBehaviour
{
    public Action<Transform> PlayerCollisionEntered;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            PlayerCollisionEntered?.Invoke(collision.transform);
        }
    }
}
