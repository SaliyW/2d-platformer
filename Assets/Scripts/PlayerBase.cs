using UnityEngine;

[RequireComponent(typeof(PlayerCollisionDetector))]
public class PlayerBase : MonoBehaviour
{
    private PlayerCollisionDetector _playerCollisionDetector;
    private int _gems = 0;
    
    private void Awake()
    {
        _playerCollisionDetector = GetComponent<PlayerCollisionDetector>();
    }

    private void OnEnable()
    {
        _playerCollisionDetector.GemTriggerEntered += TakeGem;
    }

    private void OnDisable()
    {
        _playerCollisionDetector.GemTriggerEntered -= TakeGem;
    }

    private void TakeGem(GameObject gem)
    {
        Destroy(gem);
        _gems++;
    }
}