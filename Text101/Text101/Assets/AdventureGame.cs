using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventureGame : MonoBehaviour
{
    [SerializeField] Text textComponent;
    [SerializeField] State startingState;

    private State currentState;

    // Start is called before the first frame update
    void Start()
    {
        currentState = startingState;
        textComponent.text = currentState.GetStateStory();
    }

    // Update is called once per frame
    void Update()
    {
        ManageState();
        textComponent.text = currentState.GetStateStory();
    }

    private void ManageState()
    {
        var nextStates = currentState.GetNextStates();

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentState = nextStates[0];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentState = nextStates[1];
        }
    }
}
