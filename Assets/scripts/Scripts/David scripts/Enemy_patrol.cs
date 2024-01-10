using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_patrol : MonoBehaviour
{
    public Transform[] patrolPonits; // en lista för dom olika punkterna fienden ska gå till 
    public int targetpoint; // vilken specifik punkt vi vill att den ska gå till 
    public float speed; // vilken hastighet den ska gå

    private Vector2 lastRotation; // vilken var den sita rotationen vi använde

    // Start is called before the first frame update
    void Start()
    {
        targetpoint = 0; // sätter punkten till startpunkten
        transform.position = patrolPonits[0].position; // Sätt fiendens position till startpunkten
    }
    // Update is called once per frame
    void Update()
    {
        Patrol(); // gör patrul koden

        Vector2 direction = patrolPonits[targetpoint].position - transform.position;
       
        if(lastRotation != direction)
        {
            transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);
            Debug.Log("Standing still");
        }
        lastRotation = direction;

    }
    void Patrol()
    {
        transform.position = Vector2.MoveTowards(transform.position, patrolPonits[targetpoint].position, speed * Time.deltaTime); //Gör att fienden går till

        if (transform.position == patrolPonits[targetpoint].position) // om fienden har samma po
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
