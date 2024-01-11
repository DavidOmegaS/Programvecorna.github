using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySight : MonoBehaviour
{
    // Benjamin (currently stolen from unity docs and random peoples posts)
    public Transform origin;
    public Transform target;
    RaycastHit2D hit;
    public int enemyLayer;
    bool IsChasing;
    public bool CurrentlyInSight;


    private void Start()
    {
        IsChasing = false;
        CurrentlyInSight = false;

    }

    void OnTriggerStay2D(Collider2D collider2D)
    {
        CurrentlyInSight = true;
        int layerMask = ~(1 << enemyLayer);
        hit = Physics2D.Linecast(origin.position, target.position, layerMask);
        Debug.DrawLine(origin.transform.position, target.transform.position);

        print(hit.collider);
        if (hit.collider == target.GetComponent<Collider2D>() && IsChasing != true)
        {
            StartCoroutine(ChaseTimer());
        }
    }

    void OnTriggerExit2D(Collider2D collider2D)
    {
        CurrentlyInSight = false;
    }

    IEnumerator ChaseTimer()
    {
        IsChasing = true;
        print("ILL GET YA");
        yield return new WaitForSeconds(2.5f);
        int layerMask = ~(1 << enemyLayer);
        hit = Physics2D.Linecast(origin.position, target.position, layerMask);
        if (CurrentlyInSight == true) // ser du spelaren?
        {
            print("I SEE YA");
            StartCoroutine(ChaseTimer());
        }
        else if(CurrentlyInSight == false)
        {
            print("Must have been the wind.");
            IsChasing = false;
            StopCoroutine(ChaseTimer());
        }
    }
}
