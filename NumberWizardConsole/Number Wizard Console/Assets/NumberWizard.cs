using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int maximum = 1000;
        int minimum = 1;
        
        Debug.Log("Welcome to number wizard!");
        Debug.Log("Pick a number");
        Debug.Log("The highest number is: " + maximum);
        Debug.Log("The lowest number is: " + minimum);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
