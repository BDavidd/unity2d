using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] private float screenWidthInUnits = 16f;
    [SerializeField] private float paddleSizeInUnits = 2f;
    
    private float minX;
    private float maxX;
    
    // Start is called before the first frame update
    void Start()
    {
        minX = paddleSizeInUnits / 2;
        maxX = screenWidthInUnits - minX;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 paddlePosition = new Vector2(transform.position.x, transform.position.y);


        float newPositionX = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        paddlePosition.x = Mathf.Clamp(newPositionX, minX, maxX);
        transform.position = paddlePosition;
    }
}
