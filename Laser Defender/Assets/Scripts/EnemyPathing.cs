using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    [SerializeField] private GameObject path;
    [SerializeField] private List<Transform> waypoints;

    // Start is called before the first frame update
    void Start()
    {
        AddPaths();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Workaround needed because linking multiple prefabs is no longer possible
    private void AddPaths()
    {
        waypoints.AddRange(path.transform.GetComponentsInChildren<Transform>());

        // GetComponentsInChildren returns the parent at index 0
        waypoints.RemoveAt(0);
    }
}
