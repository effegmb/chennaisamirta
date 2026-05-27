using System.Collections;
using UnityEngine;

public class CharactersWalkTransform : MonoBehaviour
{
    public float speed = 2f;
    public int currentWayPoint = 0;
    public Transform[] waypoints;

    private void Start()
    {
        StartCoroutine(CharactersWalk());
    }

    public IEnumerator CharactersWalk()
    {
        while (true)
        {
            Transform target = waypoints[currentWayPoint];

            // Move towards current waypoint
            transform.position = Vector3.MoveTowards(
                transform.position,
                target.position,
                speed * Time.deltaTime
            );

            // Rotate towards direction (optional but good)
            Vector3 dir = (target.position - transform.position).normalized;
            if (dir != Vector3.zero)
                transform.rotation = Quaternion.LookRotation(dir);

            // Check if reached
            if (Vector3.Distance(transform.position, target.position) < 0.1f)
            {
                currentWayPoint++;

                if (currentWayPoint >= waypoints.Length)
                {
                    currentWayPoint = 0; // loop back
                }
            }

            yield return null;
        }
    }
}
