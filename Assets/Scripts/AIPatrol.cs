using UnityEngine;
using UnityEngine.AI;

public class AIPatrol : MonoBehaviour
{
    public NavMeshAgent walkingAI;
    public Transform[] walkPoints;
    [SerializeField] private int currentPathID = 0;
    public Animator aiAnumator;

    void Start()
    {
        walkingAI = GetComponent<NavMeshAgent>();
        aiAnumator = GetComponent<Animator>();

        if (walkPoints.Length > 0)
        {
            //aiAnumator.SetBool("Walking", true);
            walkingAI.SetDestination(walkPoints[currentPathID].position);
        }
    }

    void Update()
    {
        // Check if agent reached destination
        if (!walkingAI.pathPending && walkingAI.remainingDistance < 0.5f)
        {
            //aiAnumator.SetBool("Walking", false);
            GoToNextPoint();
        }
    }

    void GoToNextPoint()
    {
        // Move to next point
        currentPathID++;

        // Loop back to start
        if (currentPathID >= walkPoints.Length)
        {
            currentPathID = 0;
        }

        walkingAI.SetDestination(walkPoints[currentPathID].position);
    }
}
