using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] private float screenWidthInUnits = 16f;
    [SerializeField] private float paddleSizeInUnits = 2f;
    
    private float minX;
    private float maxX;

    private GameSession gameSessionComp;
    private Ball ballComp;
    
    // Start is called before the first frame update
    void Start()
    {
        minX = paddleSizeInUnits / 2;
        maxX = screenWidthInUnits - minX;

        gameSessionComp = FindObjectOfType<GameSession>();
        ballComp = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 paddlePosition = new Vector2(transform.position.x, transform.position.y);

        paddlePosition.x = Mathf.Clamp(GetXPos(), minX, maxX);
        transform.position = paddlePosition;
    }

    private float GetXPos()
    {
        if (gameSessionComp.IsAutoPlayEnabled())
        {
            return ballComp.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }
}
