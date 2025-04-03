using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerCombat : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void TryAttackEnemy(GameObject enemy)
    {
        float minVelocity = -0.01f;

        if (_rigidbody.velocity.y < minVelocity)
        {
            Destroy(enemy);
        }
    }
}