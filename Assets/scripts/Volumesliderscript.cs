
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Volumesliderscript : MonoBehaviour
{



    public Slider myvolumeslider;

    private void Start()
    {

    }
    public void gamevolume()// sliderns value �r volymen p� musiken.
    {


        AudioListener.volume = myvolumeslider.value;

    }


}
