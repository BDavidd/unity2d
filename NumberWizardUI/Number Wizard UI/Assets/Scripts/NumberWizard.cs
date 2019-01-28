using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumberWizard : MonoBehaviour
{
    [SerializeField] int maximum;
    [SerializeField] int minimum;
    [SerializeField] private TextMeshProUGUI guessText;
    
    int guess;

    // Start is called before the first frame update
    void Start()
    {   
        StartGame();
    }

    void StartGame()
    {
        GuessAgain();
        maximum = maximum + 1;
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
        guessText.text = guess.ToString();
    }
}
