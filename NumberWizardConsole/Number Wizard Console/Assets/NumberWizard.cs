﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard : MonoBehaviour
{
    int maximum = 1000;
    int minimum = 1;
    int guess = 500;

    // Start is called before the first frame update
    void Start()
    {   
        Debug.Log("Welcome to number wizard!");
        Debug.Log("Pick a number");
        Debug.Log("The highest number is: " + maximum);
        Debug.Log("The lowest number is: " + minimum);
        
        Debug.Log("Tell me if your number is higher or lower than 500");
        Debug.Log("Push Up = Higher, Push Down = Lower, Push Enter = correct");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("Up Arrow key was pressed. " + guess);
            minimum = guess;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("Down Arrow key was pressed. " + guess);
            maximum = guess;
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Enter key was pressed");
        }
    }
}
