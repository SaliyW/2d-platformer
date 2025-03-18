using System;
using UnityEngine;

[RequireComponent(typeof(PlayerBase))]
public class PlayerCollisionDetector : MonoBehaviour
{
    private PlayerBase _controller;

    public Action<GameObject> GemTriggerEntered;

    private void Awake()
    {
        _controller = GetComponent<PlayerBase>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Gem>())
        {
            GemTriggerEntered?.Invoke(collision.gameObject);
        }
    }
}