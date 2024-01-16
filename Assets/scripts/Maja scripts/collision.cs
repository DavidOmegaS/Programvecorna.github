using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{
    private Collider2D z_collider;
    [SerializeField]
    private ContactFilter2D filter;
    private List<Collider2D> collidedObjects = new List<Collider2D>(1);

    protected virtual void Start()
    {
        z_collider = GetComponent<Collider2D>();
    }

    protected virtual void Update()
    {
        z_collider.OverlapCollider(filter, collidedObjects);
        foreach(var o in collidedObjects)
        {
            OnCollided(o.gameObject);
        }
    }

    protected virtual void OnCollided(GameObject collidedObject)
    {
        
    }
}
