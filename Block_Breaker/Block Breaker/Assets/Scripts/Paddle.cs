using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] private float screenWidthInUnits = 16f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float newPositionX = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        if (newPositionX < 1)
        {
            newPositionX = 1;
        }
        else if (newPositionX > screenWidthInUnits - 1)
        {
            newPositionX = 15;
        }

        Vector2 paddlePosition = new Vector2(newPositionX, transform.position.y);
        transform.position = paddlePosition;
    }
}
