using UnityEngine;

public class PlayerCollisionSolutions : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Gem>())
        {
            Destroy(collision.gameObject);
        }
    }
}