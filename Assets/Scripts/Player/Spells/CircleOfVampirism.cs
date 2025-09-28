using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class CircleOfVampirism : MonoBehaviour
{
    private List<GameObject> _objectsInTrigger = new();

    public GameObject GiveTarget()
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>())
        {
            _objectsInTrigger.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_objectsInTrigger.Contains(collision.gameObject))
        {
            _objectsInTrigger.Remove(collision.gameObject);
        }
    }

    private GameObject FindNearest()
    {
        GameObject nearest = null;
        float distance;
        float minDistance = float.MaxValue;

        foreach (GameObject obj in _objectsInTrigger)
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
