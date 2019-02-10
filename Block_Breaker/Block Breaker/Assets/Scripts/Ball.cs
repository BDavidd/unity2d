using UnityEngine;

public class Ball : MonoBehaviour
{
    // config params
    [SerializeField] private Paddle paddle1;
    [SerializeField] private float xPush = 2f;
    [SerializeField] private float yPush = 15f;
    [SerializeField] private AudioClip[] ballSounds;
    [SerializeField] private float randomFactor = 0.2f;

    // state
    private Vector2 paddleToBallVector;
    private bool hasStarted = false;

    // Component references
    private Rigidbody2D rigidBody2DComp;
    private AudioSource audioSourceComp;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2DComp = GetComponent<Rigidbody2D>();
        audioSourceComp = GetComponent<AudioSource>(); 
        
        paddleToBallVector = transform.position - paddle1.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            rigidBody2DComp.velocity = new Vector2(xPush, yPush);
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePosition = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePosition + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(Random.Range(0, randomFactor), 
                                            Random.Range(0, randomFactor));

        if (hasStarted)
        {
            AudioClip clip = ballSounds[Random.Range(0, ballSounds.Length)];
            audioSourceComp.PlayOneShot(clip);

            rigidBody2DComp.velocity += velocityTweak;
        }
    }
}
