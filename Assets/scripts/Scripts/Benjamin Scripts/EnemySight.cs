using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySight : MonoBehaviour
{
    // Benjamin (mostly stolen from unity docs and random peoples posts)
    public Transform origin; // enemy character - Benjamin
    public Transform target; // target, player character - Benjamin
    RaycastHit2D hit; 
    public int enemyLayer = 6; // the layermask "enemyLayer" int value - Benjamin
    public bool IsChasing; // bool if player is being chased or not - Benjamin
    public bool CurrentlyInSight; // bool if player is currently being seen or not - Benjamin

    public float waitTime; // värde för hur länge den ska vänta - David

    [SerializeField] AudioController AC;
    [SerializeField] AudioSource AS;


    private void Start()
    {
        IsChasing = false;
        CurrentlyInSight = false;

    }

    void OnTriggerEnter2D(Collider2D collider2D) 
    {
        int layerMask = ~(1 << enemyLayer); // Raycast hits all layers except the enemy layer, so it doesnt hit itself and block capability to see player - Benjamin
        hit = Physics2D.Linecast(origin.position, target.position, layerMask); // The linecast itself and the result of what it hits - Benjamin
        Debug.DrawLine(origin.transform.position, target.transform.position); // simulation of what the linecast looks like - Benjamin
        print(hit.collider); 
        if (hit.collider == target.GetComponent<BoxCollider2D>() && IsChasing != true) // if the linecast hit the player object and is not chasing the player - Benjamin
        {
            CurrentlyInSight = true;
            StartCoroutine(ChaseTimer()); // starts the chase timer, used for chase sequence - Benjamin
            AS.PlayOneShot(AC.clips[2]); // play specific sound clip - Benjamin
        }
      

     
    }

    void OnTriggerExit2D(Collider2D collider2D)
    {
        CurrentlyInSight = false; // if player goes outside of sight area - Benjamin
    }

    IEnumerator ChaseTimer() // timer to let game know the enemy is chasing you, currently doesnt do much since guards kill you instantly - Benjamin
    {
        IsChasing = true;
        print("ILL GET YA");
        int layerMask = ~(1 << enemyLayer);
        hit = Physics2D.Linecast(origin.position, target.position, layerMask);
        yield return new WaitForSeconds(waitTime);
        if (CurrentlyInSight == true) // continues the chase - Benjamin
        {
            AC.Stress = true;
            IsChasing = true; // David
            print("I SEE YA");
            StartCoroutine(ChaseTimer()); // loops the chasetimer - Benjamin
        }
        else if(CurrentlyInSight == false) // ends the chase - Benjamin
        {
            AC.Stress = false;
            print("Must have been the wind.");
            IsChasing = false; // No longer chasing - Benjamin
            StopCoroutine(ChaseTimer());
        }
    }
}
