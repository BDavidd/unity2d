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
    }

    public void OnPressHigher()
    {
        if (guess + 1 <= maximum)
        {
            minimum = guess + 1;
        }
        else
        {
            minimum = maximum;
        }

        GuessAgain();
    }

    public void OnPressLower()
    {
        if (guess - 1 >= minimum)
        {
            maximum = guess - 1;
        }
        else
        {
            maximum = minimum;
        }

        GuessAgain();
    }

    void GuessAgain()
    {
        guess = Random.Range(minimum, maximum + 1);
        guessText.text = guess.ToString();
    }
}
