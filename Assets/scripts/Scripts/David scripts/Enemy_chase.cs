using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy_chase : MonoBehaviour
{
    public EnemySight sight; // refferens till enemy sight script
   

    public Transform playerTarget; // player obejektet
    public Transform startPoint; // Punkt där fienden började
    public float speed; // Hastighet
    public float nextWaypointDistance = 3f; // hur nära fienden behöver vara en punkt för att gå vidare till nästa 

    Path path; // Fienden nuvande path

    int currentWaypoint; // nuvarande punkt som fienden siktar sig in mot
   public bool rechEndOfPath = false; // Se om vi har kommit fram till vårat mål

    Seeker seeker; // refferera sekker scriptet
    Rigidbody2D rb; // refererar rigidbody

    // Start is called before the first frame update
    void Start()
    {
        sight = GetComponentInChildren<EnemySight>();

        seeker = GetComponent<Seeker>(); // letar efter sekker i objektet
        rb = GetComponent<Rigidbody2D>(); // letar efter rigidbody2D

        startPoint.position = transform.position;

        InvokeRepeating("UpdatePath", 0f, 0.5f); // Uprepar UpdatePath varje halv sekund och väntar inte på att uprepa den 
        
    }
    void UpdatePath()
    {
        if (seeker.IsDone())
        {
            if (sight.CurrentlyInSight) // Om fienden ser spelaren
            {
                seeker.StartPath(rb.position, playerTarget.position, OnPathComplete); // Startar path ifrån fienden poistion till spellarens position
            }
            else
            {
                 seeker.StartPath(rb.position, startPoint.position, OnPathComplete);
            }

            //if (sight.IsChasing == false && rechEndOfPath == true)
            {
              //  transform.position = startPoint.position; 
            }

        }
      
    }

    void OnPathComplete(Path p)
    {
        if (!p.error) // om vi inte fick några errors när vi genererade path
        {
            path = p; // sätter vi våran path till p
            currentWaypoint = 0; // gör att den startar från början av den nya väggen
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (path == null) // om vi inte har en tillgänlig väg 
        {
            return; // går vi ut ur funktionen 
        }

        if(currentWaypoint >= path.vectorPath.Count) // om våran nuvarande målpunkt är störe eller lika mycket som den tatala punkter längs vägen
        {
            rechEndOfPath = true; // den är nått målet
            return;
        }
        else
        {
            rechEndOfPath = false; // annars har den inte nått målet
        }

       

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized; // 
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath [currentWaypoint]);
        
        if (distance < nextWaypointDistance)
        {
            currentWaypoint++; // plusar vi på med ett 
        }

    }
}
