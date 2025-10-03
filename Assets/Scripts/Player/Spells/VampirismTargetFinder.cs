using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class VampirismTargetFinder : MonoBehaviour
{
    private List<Enemy> _objectsInTrigger = new();
    private bool _isVampirismActive = false;

    private void Start()
    {
        gameObject.SetActive(_isVampirismActive);
    }

    public void ChangeActivity()
    {
        _isVampirismActive = !_isVampirismActive;

        gameObject.SetActive(_isVampirismActive);
    }

    public Enemy GiveTarget()
    {
        int oneObject = 1;

        if (_objectsInTrigger.Count > oneObject)
        {
            return FindNearest();
        }
        else if (_objectsInTrigger.Count == oneObject)
        {
            return _objectsInTrigger[0];
        }
        else
        {
            return null;
        }
    }

    public bool TryGiveTarget(out Enemy enemy)
    {
        int oneObject = 1;

        if (_objectsInTrigger.Count > oneObject)
        {
            enemy = FindNearest();
        }
        else if (_objectsInTrigger.Count == oneObject)
        {
            enemy = _objectsInTrigger[0];
        }
        else
        {
            enemy = null;
            return false;
        }

        return true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            _objectsInTrigger.Add(enemy);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.gameObject.TryGetComponent(out Enemy enemy);

        if (_objectsInTrigger.Contains(enemy))
        {
            _objectsInTrigger.Remove(enemy);
        }
    }

    private Enemy FindNearest()
    {
        Enemy nearest = null;
        float distance;
        float minDistance = float.MaxValue;

        foreach (Enemy obj in _objectsInTrigger)
        {
            distance = Vector3.Distance(transform.position, obj.transform.position);

            if (distance < minDistance)
            {
                minDistance = distance;
                nearest = obj;
            }
        }

        return nearest;
    }
}
