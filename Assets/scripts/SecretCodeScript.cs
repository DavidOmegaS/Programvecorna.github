using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SecretCodeScript : MonoBehaviour
{


    public TMP_InputField mainInputfield;
    // Start is called before the first frame update
    void Start()
    {
     
    

    }

    // Update is called once per frame
    void Update()
    {

        if (mainInputfield.text==("Heavy Metal"))
        {
            print("yeeeeeeeee");
        }
        
    }
}
