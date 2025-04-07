using UnityEngine;

public class Cherry : MonoBehaviour, IComponent
{
    public void Accept(IVisitor visitor)
    {
        visitor.VisitCherry(this);
    }
}