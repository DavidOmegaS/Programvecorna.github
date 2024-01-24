using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleTest : MonoBehaviour
{
    public GameObject prefabster;
    public ParticleSystem psystem;
    // Start is called before the first frame update
    void Start()
    {
        ParticleSystem psystem = GameObject.Find("confetti").GetComponent<ParticleSystem>();
      
    }

    // Update is called once per frame
    void Update()
    {
        Instantiate(prefabster, transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider other)
    {
        
    }
}
