using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy_chase : MonoBehaviour
{
    public EnemySight sight;
    public bool test;

    public Transform playerTarget;
    public Transform startPoint;
    public float speed;
    public float nextWaypointDistance = 3f;

    Path path;
    int currentWaypoint;
    bool rechEndOfPath = false; // Se om vi har kommit fram till vårat mål

    Seeker seeker; // refferera sekker scriptet
    Rigidbody2D rb; // refererar rigidbody

    // Start is called before the first frame update
    void Start()
    {
        sight = GetComponentInChildren<EnemySight>();

        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        startPoint.position = transform.position;

        InvokeRepeating("UpdatePath", 0f, 0.5f);
        
    }
    void UpdatePath()
    {
        if (seeker.IsDone())
        {
            if (sight.IsChasing)
            {
                seeker.StartPath(rb.position, playerTarget.position, OnPathComplete);
            }
            else
            {
                seeker.StartPath(rb.position, startPoint.position, OnPathComplete);
            }
           
        }
      
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (path == null)
        {
            return;
        }

        if(currentWaypoint >= path.vectorPath.Count)
        {
            rechEndOfPath = true; // den är nått målet
            return;
        }
        else
        {
            rechEndOfPath = false; // annars har den inte nått målet
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath [currentWaypoint]);
        
        if (distance < nextWaypointDistance)
        {
            currentWaypoint++; // plusar vi på med ett 
        }

    }
}
