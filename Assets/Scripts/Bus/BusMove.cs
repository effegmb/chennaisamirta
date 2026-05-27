using UnityEngine;
using System.Collections;

public class BusMove : MonoBehaviour
{
    public Transform busTransform;
    public Transform[] busMov;
    [SerializeField] private int currentPathID = 0;

    public float speed = 5f;

    void Start()
    {
        if (busMov.Length > 0)
        {
            StartCoroutine(MoveBus());
        }
    }

    IEnumerator MoveBus()
    {
        while (true)
        {
            Transform target = busMov[currentPathID];

            // Move until reach target
            while (Vector3.Distance(busTransform.position, target.position) > 0.2f)
            {
                busTransform.position = Vector3.MoveTowards(
                    busTransform.position,
                    target.position,
                    speed * Time.deltaTime
                );

                yield return null;
            }

            // If last point reached → STOP
            if (currentPathID >= busMov.Length - 1)
            {
                Debug.Log("Bus reached final point");
                yield break; // ✅ stops coroutine properly
            }

            currentPathID++;
        }
    }
}