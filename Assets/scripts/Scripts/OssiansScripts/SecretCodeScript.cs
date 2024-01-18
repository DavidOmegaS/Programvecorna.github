using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SecretCodeScript : MonoBehaviour
{
    //skit i detta scriptet jag orkade inte göra mer

    public TMP_InputField mainInputfield;
    // Start is called before the first frame update
    void Start()
    {
     
    

    }

    // Update is called once per frame
    void Update()
    {

        if (mainInputfield.text==("OUB"))
        {
            print("yeeeeeeeee");
        }
        
    }

   public void clearText()
    {
      
        mainInputfield.text = string.Empty;
        
    }
}
