using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collidable : MonoBehaviour
{
    public ContactFilter2D contactFilter;
    private BoxCollider2D boxCollider2d;
    private Collider2D[] hit = new Collider2D[10];

    protected virtual void Start()
    {
        boxCollider2d = GetComponent<BoxCollider2D>();
    }

    protected virtual void Update()
    {
        boxCollider2d.OverlapCollider(contactFilter, hit);
        for (int i = 0; i < hit.Length; i++)
        {
            if (hit[i] != null)
            {
                OnCollide(hit[i]);
            }

            hit[i] = null;
        }
    }

    protected virtual void OnCollide(Collider2D coll)
    {
        Debug.Log(coll.name);
    }
}
