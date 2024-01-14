using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai_sight : MonoBehaviour
{
   public Enemy_chase chase;
    // Start is called before the first frame update
    void Start()
    {
        chase = GetComponentInParent<Enemy_chase>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = chase.playerTarget.position - transform.position;
        transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);
    }
}
