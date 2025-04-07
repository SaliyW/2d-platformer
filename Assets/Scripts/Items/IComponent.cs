public interface IComponent
{
    void Accept(IVisitor visitor);
}