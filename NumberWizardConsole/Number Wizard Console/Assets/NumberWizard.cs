using System.Collections;
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
        Debug.Log("Salut! Welcome to Number Wizard!");
        Debug.Log("Pick a number and I'll show you that I can guess it.");
        Debug.Log($"Your number must not be higher than {maximum}");
        Debug.Log($"And it can't be lower than {minimum}");

        Debug.Log("Push Up = Higher, Push Down = Lower, Push Enter = correct \n");
        Debug.Log($"Tell me if your number is higher or lower than {guess}");

        maximum = maximum + 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            minimum = guess;
            guess = (maximum + minimum) / 2;
            Debug.Log($"So higher... Could it be {guess}?");
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            maximum = guess;
            guess = (maximum + minimum) / 2;
            Debug.Log($"So lower... Could it be {guess}?");
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log($"I knew from the beginning that it is {guess}!");
        }
    }
}
