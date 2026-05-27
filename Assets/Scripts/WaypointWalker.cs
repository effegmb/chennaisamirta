using UnityEngine;

public class WaypointWalker : MonoBehaviour
{
    public Transform[] waypoints;
    public float moveSpeed = 2f;
    public float rotationSpeed = 5f;
    public float reachDistance = 0.2f;

    private int currentWaypointIndex = 0;
    private bool movingForward = true;   // Direction control
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isWalking", true);
    }

    void Update()
    {
        if (waypoints.Length == 0) return;

        Transform targetWaypoint = waypoints[currentWaypointIndex];

        // Direction
        Vector3 direction = (targetWaypoint.position - transform.position).normalized;

        // Move
        transform.position += direction * moveSpeed * Time.deltaTime;

        // Rotate smoothly
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        // Check if reached waypoint
        if (Vector3.Distance(transform.position, targetWaypoint.position) < reachDistance)
        {
            if (movingForward)
            {
                currentWaypointIndex++;

                if (currentWaypointIndex >= waypoints.Length - 1)
                {
                    movingForward = false;  // Reverse direction
                }
            }
            else
            {
                currentWaypointIndex--;

                if (currentWaypointIndex <= 0)
                {
                    movingForward = true;   // Forward again
                }
            }
        }
    }
}