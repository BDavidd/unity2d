using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    [SerializeField] private GameObject path;
    [SerializeField] private List<Transform> waypoints;
    [SerializeField] private float moveSpeed = 2f;

    private int waypointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        AddPaths();
        transform.position = waypoints[waypointIndex].position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (waypointIndex <= waypoints.Count - 1)
        {
            var targetPosition = waypoints[waypointIndex].position;
            var movementThisFrame = moveSpeed * Time.deltaTime;

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);

            if (transform.position == targetPosition)
            {
                ++waypointIndex;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Workaround needed because linking multiple prefabs is no longer possible
    private void AddPaths()
    {
        waypoints.AddRange(path.transform.GetComponentsInChildren<Transform>());

        // GetComponentsInChildren returns the parent at index 0
        waypoints.RemoveAt(0);
    }
}
