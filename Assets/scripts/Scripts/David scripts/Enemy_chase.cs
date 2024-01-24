using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy_chase : MonoBehaviour
{
    public EnemySight sight; // refferens till enemy sight script
   

    public Transform playerTarget; // player obejektet
    public Transform startPoint; // Punkt d�r fienden b�rjade
    public float speed; // Hastighet
    public float nextWaypointDistance = 3f; // hur n�ra fienden beh�ver vara en punkt f�r att g� vidare till n�sta 

    Path path; // Fienden nuvande path

    int currentWaypoint; // nuvarande punkt som fienden siktar sig in mot
   public bool rechEndOfPath = false; // Se om vi har kommit fram till v�rat m�l

    Seeker seeker; // refferera sekker scriptet
    Rigidbody2D rb; // refererar rigidbody

    // Start is called before the first frame update
    void Start()
    {
        sight = GetComponentInChildren<EnemySight>();

        seeker = GetComponent<Seeker>(); // letar efter sekker i objektet
        rb = GetComponent<Rigidbody2D>(); // letar efter rigidbody2D

        startPoint.position = transform.position;

        InvokeRepeating("UpdatePath", 0f, 0.5f); // Uprepar UpdatePath varje halv sekund och v�ntar inte p� att uprepa den 
        
    }
    void UpdatePath()
    {
        if (seeker.IsDone())
        {
            if (sight.CurrentlyInSight) // Om fienden ser spelaren
            {
                seeker.StartPath(rb.position, playerTarget.position, OnPathComplete); // Startar path ifr�n fienden poistion till spellarens position
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
        if (!p.error) // om vi inte fick n�gra errors n�r vi genererade path
        {
            path = p; // s�tter vi v�ran path till p
            currentWaypoint = 0; // g�r att den startar fr�n b�rjan av den nya v�ggen
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (path == null) // om vi inte har en tillg�nlig v�g 
        {
            return; // g�r vi ut ur funktionen 
        }

        if(currentWaypoint >= path.vectorPath.Count) // om v�ran nuvarande m�lpunkt �r st�re eller lika mycket som den tatala punkter l�ngs v�gen
        {
            rechEndOfPath = true; // den �r n�tt m�let
            return;
        }
        else
        {
            rechEndOfPath = false; // annars har den inte n�tt m�let
        }

       

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized; // 
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath [currentWaypoint]);
        
        if (distance < nextWaypointDistance)
        {
            currentWaypoint++; // plusar vi p� med ett 
        }

    }
}
