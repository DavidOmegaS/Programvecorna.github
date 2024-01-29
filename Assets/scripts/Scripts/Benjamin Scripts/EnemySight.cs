using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySight : MonoBehaviour
{
    // Benjamin (mostly stolen from unity docs and random peoples posts)
    public Transform origin; // enemy character
    public Transform target; // target, player character
    RaycastHit2D hit; 
    public int enemyLayer = 6; // the layermask "enemyLayer" int value
    public bool IsChasing; // bool if player is being chased or not
    public bool CurrentlyInSight; // bool if player is currently being seen or not

    public float waitTime; // v�rde f�r hur l�nge den ska v�nta - David

    [SerializeField] AudioController AC;
    [SerializeField] AudioSource AS;


    private void Start()
    {
        IsChasing = false;
        CurrentlyInSight = false;

    }

    void OnTriggerEnter2D(Collider2D collider2D) 
    {
        int layerMask = ~(1 << enemyLayer); // Raycast hits all layers except the enemy layer, so it doesnt hit itself and block capability to see player
        hit = Physics2D.Linecast(origin.position, target.position, layerMask); // The linecast itself and the result of what it hits
        Debug.DrawLine(origin.transform.position, target.transform.position); // simulation of what the linecast looks like
        print(hit.collider); 
        if (hit.collider == target.GetComponent<BoxCollider2D>() && IsChasing != true) // if the linecast hit the player object and is not chasing the player
        {
            CurrentlyInSight = true;
            StartCoroutine(ChaseTimer()); // starts the chase timer, used for chase sequence
            AS.PlayOneShot(AC.clips[2]);
        }
      

     
    }

    void OnTriggerExit2D(Collider2D collider2D)
    {
        CurrentlyInSight = false; // if player goes outside of sight area
    }

    IEnumerator ChaseTimer()
    {
        IsChasing = true;
        print("ILL GET YA");
        int layerMask = ~(1 << enemyLayer);
        hit = Physics2D.Linecast(origin.position, target.position, layerMask);
        yield return new WaitForSeconds(waitTime);
        if (CurrentlyInSight == true) // continues the chase
        {
            AC.Stress = true;
            IsChasing = true; // David
            print("I SEE YA");
            StartCoroutine(ChaseTimer()); // loops the chasetimer
        }
        else if(CurrentlyInSight == false) // ends the chase
        {
            AC.Stress = false;
            print("Must have been the wind.");
            IsChasing = false; // No longer chasing
            StopCoroutine(ChaseTimer());
        }
    }
}
