using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandMachine : MonoBehaviour
{
    [SerializeField] GameObject SandstormObject; // The prefab sandstorm with script and animation
    public bool MachineOn; // is script true?

    [SerializeField] Transform point1; // first point
    [SerializeField] Transform point2; // second point
    Transform target; // point which spawner object travels to
    [SerializeField] float timer; // is a timer
    [SerializeField] float spawntime; // current amount of time needed for prefab Sandstorm to spawn
    public float minspawntime; // minimum spawntime
    public float maxspawntime; // maximum spawntime
    [SerializeField] Transform Spawnpoint; // place where prefab sandstorm spawns from
    // Start is called before the first frame update
    void Start()
    {
        target = point1; 
        spawntime = Random.Range(minspawntime, maxspawntime); // randomizes a range between min and max spawntime, for more random sandstorms.
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;

        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, 6 * Time.deltaTime); // moves at a speed of 6 towards current target point


        if((Vector2)transform.position == (Vector2)point1.position) // if at point1, new target is point2
        {
            target = point2;
        }
        else if ((Vector2)transform.position == (Vector2)point2.position) // if at point2, new target is point1
        {
            target = point1; 
        }
        
        if(timer >= spawntime) // timer is reset to zero, new spawntime and instantiates the prefab sandstorm
        {
            timer = 0;
            spawntime = Random.Range(minspawntime, maxspawntime);
            print("i hate sand");
            Instantiate(SandstormObject, Spawnpoint.position, Quaternion.identity);
        }
    }
}

