using TMPro;
using UnityEngine;

[RequireComponent(typeof(PlayerHealth))]
public class PlayerBag : MonoBehaviour, IVisitor
{
    [SerializeField] private TextMeshProUGUI _gemsValue;

    private int _gems = 0;
    private PlayerHealth _health;

    private void Awake()
    {
        _health = GetComponent<PlayerHealth>();
        _gemsValue.text = _gems.ToString();
    }

    public void VisitGem(Gem item)
    {
        Destroy(item.gameObject);
        _gems++;
        _gemsValue.text = _gems.ToString();
    }

    public void VisitCherry(Cherry item)
    {
        _health.TakeCherry(item);
    }
}