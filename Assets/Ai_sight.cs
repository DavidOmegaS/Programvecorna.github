using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai_sight : MonoBehaviour
{
   public Enemy_chase chase;
    public EnemySight sight;

    public float t = 75;
    // Start is called before the first frame update
    void Start()
    {
        chase = GetComponentInParent<Enemy_chase>();
        sight = GetComponentInChildren<EnemySight>();
    }

    // Update is called once per frame
    void Update()
    {
        if (sight.CurrentlyInSight == true)
        {
            Vector2 direction = chase.playerTarget.position - transform.position;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(Vector3.forward, direction), t * Time.deltaTime);
        }
        else if (sight.IsChasing == false)
        {
            Vector2 direction = chase.startPoint.position - transform.position;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(Vector3.forward, direction), t * Time.deltaTime);

        }
       
    }
}
