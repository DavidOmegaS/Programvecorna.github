using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_sight : MonoBehaviour
{
    public Transform[] lookPonits; // en lista f�r dom olika punkterna fienden ska titta p� 
    //public int targetpoint; // vilken specifik punkt vi vill att den ska titta p�

    public Enemy_patrol target;
    public int lookTarget;

   

    // Start is called before the first frame update
    void Start()
    {
        target = GetComponentInParent<Enemy_patrol>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = lookPonits[target.targetpoint].position - transform.position;
        transform.rotation = Quaternion.FromToRotation(Vector3.down, direction);

       
      
    }
}