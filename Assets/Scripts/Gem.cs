using UnityEngine;

public class Gem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            Destroy(gameObject);
        }
    }
}