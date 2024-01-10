using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Benjamin (currently stolen from unity docs)
    public Transform origin;
    public Transform target;
    RaycastHit2D hit;
    public int enemyLayer;

    

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        int layerMask = ~(1 << enemyLayer);
        hit = Physics2D.Linecast(origin.position, target.position, layerMask);
        Debug.DrawLine(origin.transform.position, target.transform.position);

        print(hit.collider);
        
        if (hit.collider == target.GetComponent<Collider2D>())
        {
            print("GOTTEM");
        }
    }
}
