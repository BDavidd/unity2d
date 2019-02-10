using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float padding = 0.5f;
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private float projectileSpeed = 20f;
    [SerializeField] private float projectileFiringPeriod = 0.05f;

    private Coroutine firingCoroutine;

    private float xMin;
    private float xMax;
    private float yMin;
    private float yMax;

    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBoundaries();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();
    } 

    private void Fire()
    {
        if (Input.GetButtonDown("Fire1") && firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(FireContinuously());
        }

        if (Input.GetButtonUp("Fire1") && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity);
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);

            yield return new WaitForSeconds(projectileFiringPeriod);
        }
    }

    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);

        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        var newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);

        transform.position = new Vector2(newXPos, newYPos);
    }

    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        var minLimits = new Vector3(0, 0);
        var maxLimits = new Vector3(1, 1);

        xMin = gameCamera.ViewportToWorldPoint(minLimits).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(maxLimits).x - padding;

        yMin = gameCamera.ViewportToWorldPoint(minLimits).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(maxLimits).y - padding;
    }
}
