using UnityEngine;

public class Cherry : MonoBehaviour, IComponent
{
    private const int _healValue = 20;

    public int HealValue => _healValue;

    public void Accept(IVisitor visitor)
    {
        visitor.VisitCherry(this);
    }
}