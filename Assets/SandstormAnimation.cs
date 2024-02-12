using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sandstorm : MonoBehaviour
{
    [SerializeField] float timer;
    [SerializeField] float destructiontimer;
    [SerializeField] int speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;

        transform.position += speed * Time.deltaTime * transform.right; // moves towards the right at a constant speed

        if(timer >= destructiontimer) // destroys itself after a set period of time
        {
            Destroy(this.gameObject);
        }
    }
}