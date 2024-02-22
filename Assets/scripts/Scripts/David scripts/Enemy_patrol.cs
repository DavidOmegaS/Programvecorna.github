using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_patrol : MonoBehaviour
{
    public Transform[] patrolPonits; // en lista f�r dom olika punkterna fienden ska g� till 
    public Transform startPoint;
    public int targetpoint; // vilken specifik punkt vi vill att den ska g� till 
    public float speed; // vilken hastighet den ska g�
    public bool isWalking;

    public float wait = 2; // hur l�nge den ska v�nta
    private float waitTime; // hur l�nga den har v�ntat
    private bool isWaiting; // om den v�ntar 

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        targetpoint = 0; // s�tter punkten till startpunkten

       
            transform.position = patrolPonits[0].position; // S�tt fiendens position till startpunkten
       
      
        
        
        waitTime = 0;

        animator = GetComponent<Animator>();
        animator.SetBool("EWalk", false);

    }
    // Update is called once per frame
    void Update()
    {
        Patrol(); // g�r patrul koden
    }
    void Patrol()
    {
       
            
        
        transform.position = Vector2.MoveTowards(transform.position, patrolPonits[targetpoint].position, speed * Time.deltaTime); //G�r att fienden g�r till den nuvarande punkten

        if (transform.position == patrolPonits[targetpoint].position ) // Om fienden st�r vid den punkten den ska st� p�
        {
            isWaiting = true; // v�ntar den
        }
        else
        {
            isWaiting = false; 
        }

        if (isWaiting == true) // om den v�ntar 
        {
           
            waitTime -= Time.deltaTime; // r�knar vi ner fr�n hur l�nge vi har v�ntat
            animator.SetBool("EWalk", false);
        }
        else
        {
            animator.SetBool("EWalk", true);
        }

        if (waitTime == 0 || waitTime <0) // om den har v�ntar lika mycket eller mer �n noll
        {
            waitTime = 0; // s�tter vi den till noll 

        }
        if (transform.position == patrolPonits[targetpoint].position && waitTime == 0  ) // om fienden har samma position som punkten och den har v�ntat tillr�kligt l�nge
        {
            IncresTargetint();
            waitTime = wait; // resetar vi waittime
        }

        
        
    }
    void IncresTargetint()
    {
        targetpoint++; // adderar 1 p� v�rdet 

        if (targetpoint == patrolPonits.Length) // om fienden har g�t till alla punkter p� listan
        {
            targetpoint = 0; // s�tter vi att den g�r till den f�rsta punkten p� listan
        }
    }
        
        
   
}
