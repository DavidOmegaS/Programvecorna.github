using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySight : MonoBehaviour
{
    // Benjamin (currently stolen from unity docs)
    public Transform origin;
    public Transform target;
    RaycastHit2D hit;
    public int enemyLayer;
    bool IsChasing;

    private void Start()
    {
        IsChasing = false;
    }

    void OnTriggerStay2D(Collider2D collider2D)
    {
        int layerMask = ~(1 << enemyLayer);
        hit = Physics2D.Linecast(origin.position, target.position, layerMask);
        Debug.DrawLine(origin.transform.position, target.transform.position);

        print(hit.collider);
        
        if (hit.collider == target.GetComponent<Collider2D>() && IsChasing != true)
        {
            StartCoroutine(ChaseTimer());
        }
    }

    IEnumerator ChaseTimer()
    {
        IsChasing = true;
        print("ILL GET YA");
        yield return new WaitForSeconds(5);
        print("Must have been the wind.");
        IsChasing = false;
        StopCoroutine(ChaseTimer());
    }
}
