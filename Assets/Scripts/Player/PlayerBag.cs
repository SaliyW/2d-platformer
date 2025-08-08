using UnityEngine;

[RequireComponent(typeof(PlayerHealth))]
public class PlayerBag : MonoBehaviour, IVisitor
{
    [SerializeField] private int _gems = 0;

    private PlayerHealth _health;

    private void Awake()
    {
        _health = GetComponent<PlayerHealth>();
    }

    public void VisitGem(Gem item)
    {
        Destroy(item.gameObject);
        _gems++;
    }

    public void VisitCherry(Cherry item)
    {
        _health.TakeCherry(item);
    }
}