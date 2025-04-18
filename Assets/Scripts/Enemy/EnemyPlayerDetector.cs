﻿using System;
using UnityEngine;

public class EnemyPlayerDetector : MonoBehaviour
{
    public Action<Transform> PlayerTriggerEntered;
    public Action PlayerTriggerExited;
    public Action<Transform> PlayerCollisionEntered;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            PlayerCollisionEntered?.Invoke(collision.transform);
        }
    }

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
