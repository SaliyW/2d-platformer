using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerCombat : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private PlayerVampirism _playerVampirism;    

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerVampirism = GetComponent<PlayerVampirism>();
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