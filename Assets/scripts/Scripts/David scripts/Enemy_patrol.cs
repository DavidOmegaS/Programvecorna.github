using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_patrol : MonoBehaviour
{
    public Transform[] patrolPonits;
    public int targetpoint;
    public float speed;

    private float rotationspeed;
    // Start is called before the first frame update
    void Start()
    {
        targetpoint = 0;
        transform.position = patrolPonits[0].position;
    }
    // Update is called once per frame
    void Update()
    {
        Patrol();

        
    }
    void Patrol()
    {
        transform.position = Vector2.MoveTowards(transform.position, patrolPonits[targetpoint].position, speed * Time.deltaTime);

        gameObject.transform.LookAt(patrolPonits[targetpoint]);

        if (transform.position == patrolPonits[targetpoint].position)
        {
            IncresTargetint();
        }
    }
    void IncresTargetint()
    {
        targetpoint++; // adderar 1 på värdet 
        if (targetpoint == patrolPonits.Length)
        {
            targetpoint = 0;
        }
    }
        
        
   
}
