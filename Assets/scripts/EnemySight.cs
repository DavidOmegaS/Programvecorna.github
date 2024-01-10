using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Benjamin (currently stolen from unity docs)
    public Transform origin;
    public Transform target;
    RaycastHit2D hit;

    private void FixedUpdate()
    {
        hit = Physics2D.Linecast(origin.position, target.position);
        Debug.DrawLine(origin.transform.position, target.transform.position);

        print(hit.collider);
    }
}
