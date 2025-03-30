using UnityEngine;

[RequireComponent(typeof(PlayerCollisionDetector))]
public class PlayerBag : MonoBehaviour
{
    [SerializeField] private int _gems = 0;

    private PlayerCollisionDetector _collisionDetector;

    private void Awake()
    {
        _collisionDetector = GetComponent<PlayerCollisionDetector>();
    }

    private void OnEnable()
    {
        _collisionDetector.GemTriggerEntered += TakeGem;
    }

    private void OnDisable()
    {
        _collisionDetector.GemTriggerEntered -= TakeGem;
    }

    private void TakeGem(GameObject gem)
    {
        Destroy(gem);
        _gems++;
    }
}