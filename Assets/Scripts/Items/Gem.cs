using UnityEngine;

public class Gem : MonoBehaviour, IComponent
{
    public void Accept(IVisitor visitor)
    {
        visitor.VisitGem(this);
    }
}