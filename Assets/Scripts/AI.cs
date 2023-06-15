using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public Transform Player; // Reference to the main character's transform
    private Pathfinding pathfinding;
    private List<Vector2> path;
    private int currentWaypoint = 0;
    private bool isChasing = false;

    private void Awake()
    {
        pathfinding = GetComponent<Pathfinding>();
    }

    private void Update()
    {
        if (isChasing)
        {
            UpdatePath();
            MoveBot();
        }
    }

    private void UpdatePath()
    {
        // Calculate the path using A* pathfinding
        path = pathfinding.FindPath(transform.position, target.position);
        currentWaypoint = 0;
    }

    private void MoveBot()
    {
        if (path == null || path.Count == 0)
            return;

        // Move towards the current waypoint
        Vector2 direction = (path[currentWaypoint] - (Vector2)transform.position).normalized;
        transform.Translate(direction * Time.deltaTime);

        // Check if the bot has reached the current waypoint
        if (Vector2.Distance(transform.position, path[currentWaypoint]) < 0.1f)
        {
            currentWaypoint++;

            // Check if the bot has reached the end of the path
            if (currentWaypoint >= path.Count)
            {
                // Perform attack action here
                Attack();
            }
        }
    }

    private void Attack()
    {
        // Implement the attack logic here
        Debug.Log("Attacking the main character!");
    }

    // Call this method to start chasing the main character
    public void StartChasing()
    {
        isChasing = true;
    }

    // Call this method to stop chasing the main character
    public void StopChasing()
    {
        isChasing = false;
        path = null;
    }
}
}
