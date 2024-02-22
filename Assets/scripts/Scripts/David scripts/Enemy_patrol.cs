using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_patrol : MonoBehaviour
{
    public Transform[] patrolPonits; // en lista för dom olika punkterna fienden ska gå till 
    public Transform startPoint;
    public int targetpoint; // vilken specifik punkt vi vill att den ska gå till 
    public float speed; // vilken hastighet den ska gå
    public bool isWalking;

    public float wait = 2; // hur länge den ska vänta
    private float waitTime; // hur länga den har väntat
    private bool isWaiting; // om den väntar 

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        targetpoint = 0; // sätter punkten till startpunkten

       
            transform.position = patrolPonits[0].position; // Sätt fiendens position till startpunkten
       
      
        
        
        waitTime = 0;

        animator = GetComponent<Animator>();
        animator.SetBool("EWalk", false);

    }
    // Update is called once per frame
    void Update()
    {
        Patrol(); // gör patrul koden
    }
    void Patrol()
    {
       
            
        
        transform.position = Vector2.MoveTowards(transform.position, patrolPonits[targetpoint].position, speed * Time.deltaTime); //Gör att fienden går till den nuvarande punkten

        if (transform.position == patrolPonits[targetpoint].position ) // Om fienden står vid den punkten den ska stå på
        {
            isWaiting = true; // väntar den
        }
        else
        {
            isWaiting = false; 
        }

        if (isWaiting == true) // om den väntar 
        {
           
            waitTime -= Time.deltaTime; // räknar vi ner från hur länge vi har väntat
            animator.SetBool("EWalk", false);
        }
        else
        {
            animator.SetBool("EWalk", true);
        }

        if (waitTime == 0 || waitTime <0) // om den har väntar lika mycket eller mer än noll
        {
            waitTime = 0; // sätter vi den till noll 

        }
        if (transform.position == patrolPonits[targetpoint].position && waitTime == 0  ) // om fienden har samma position som punkten och den har väntat tillräkligt länge
        {
            IncresTargetint();
            waitTime = wait; // resetar vi waittime
        }

        
        
    }
    void IncresTargetint()
    {
        targetpoint++; // adderar 1 på värdet 

        if (targetpoint == patrolPonits.Length) // om fienden har gåt till alla punkter på listan
        {
            targetpoint = 0; // sätter vi att den går till den första punkten på listan
        }
    }
        
        
   
}
