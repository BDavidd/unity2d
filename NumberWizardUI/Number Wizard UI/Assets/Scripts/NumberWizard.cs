using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard : MonoBehaviour
{
    [SerializeField] int maximum;
    [SerializeField] int minimum;
    int guess;

    // Start is called before the first frame update
    void Start()
    {   
        StartGame();
    }

    void StartGame()
    {
        maximum = maximum + 1;
        GuessAgain();
    }

    public void OnPressHigher()
    {
        minimum = guess;
        GuessAgain();
    }

    public void OnPressLower()
    {
        maximum = guess;
        GuessAgain();
    }

    void GuessAgain()
    {
        guess = (maximum + minimum) / 2;
    }
}
