using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _speed;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float minY = -1;

        Vector3 nextPosition = Vector3.Lerp(transform.position, _target.position + _offset, Time.deltaTime * _speed);

        if (nextPosition.y < minY)
        {
            nextPosition.y = minY;
        }

        transform.position = nextPosition;
    }
}