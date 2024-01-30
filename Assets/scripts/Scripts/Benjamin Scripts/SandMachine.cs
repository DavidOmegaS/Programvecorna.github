using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandMachine : MonoBehaviour
{
    [SerializeField] GameObject SandstormObject;
    public bool MachineOn;

    [SerializeField] Transform point1;
    [SerializeField] Transform point2;
    Transform target;
    [SerializeField] float timer;
    [SerializeField] float spawntime;

    
    // Start is called before the first frame update
    void Start()
    {
        target = point1;
        spawntime = Random.Range(6, 9);
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;

        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, 1 * Time.deltaTime);


        if((Vector2)transform.position == (Vector2)point1.position)
        {
            target = point2;
        }
        else if ((Vector2)transform.position == (Vector2)point2.position)
        {
            target = point1; 
        }
        
        if(timer >= spawntime)
        {
            timer = 0;
            spawntime = Random.Range(6, 9);
            print("i hate sand");
            Instantiate(SandstormObject, transform);
        }
    }
}

