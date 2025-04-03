using UnityEngine;

public class PlayerBag : MonoBehaviour
{
    [SerializeField] private int _gems = 0;

    public void TakeGem(GameObject gem)
    {
        Destroy(gem);
        _gems++;
    }
}