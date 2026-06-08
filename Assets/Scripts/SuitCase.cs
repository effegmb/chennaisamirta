/*using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class SuitCase : MonoBehaviour
{
    [Header("Rotations")]
    public Quaternion inHandRotation;
    public Quaternion releaseHandRotation;

    public Transform player; // assign XR Rig / Camera
    public float followSpeed = 5f;
    public float distanceFromPlayer = 0.8f;

    private XRGrabInteractable grab;
    private bool isHolding = false;

    void Awake()
    {
        grab = GetComponent<XRGrabInteractable>();

        grab.selectEntered.AddListener(OnGrab);
        grab.selectExited.AddListener(OnRelease);
    }

    void OnGrab(SelectEnterEventArgs args)
    {
        isHolding = true;

        // Stop XR from controlling position
        grab.trackPosition = false;
        grab.trackRotation = false;

        transform.rotation = releaseHandRotation;
    }

    void OnRelease(SelectExitEventArgs args)
    {
        isHolding = false;

        grab.trackPosition = true;
        grab.trackRotation = true;

        transform.rotation = inHandRotation;
    }

    void Update()
    {
        if (!isHolding) return;

        // Target position in front of player
        Vector3 targetPos = player.position + player.right * distanceFromPlayer;

        // Keep same Y (no flying)
        targetPos.y = transform.position.y;

        // Smooth follow
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * followSpeed);
    }
}
*/

using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class SuitCase : MonoBehaviour
{
    [Header("Rotations")]
    public Quaternion inHandRotation;
    public Quaternion releaseHandRotation;

    [Header("Follow Settings")]
    public Transform player;
    public float followSpeed = 5f;
    public float distanceFromPlayer = 3f;
    public float forwordDistance = 1;

    [Header("Ground Check")]
    public Transform rayPoint; // Assign custom point
    public float rayDistance = 5f;
    public float groundOffset = 0.05f;
    public LayerMask groundLayer;

    private XRGrabInteractable grab;
    private bool isHolding = false;

    void Awake()
    {
        grab = GetComponent<XRGrabInteractable>();

        grab.selectEntered.AddListener(OnGrab);
        grab.selectExited.AddListener(OnRelease);
    }

    void OnGrab(SelectEnterEventArgs args)
    {
        isHolding = true;

        grab.trackPosition = false;
        grab.trackRotation = false;

        transform.rotation = releaseHandRotation;
    }

    void OnRelease(SelectExitEventArgs args)
    {
        isHolding = false;

        grab.trackPosition = true;
        grab.trackRotation = true;

        transform.rotation = inHandRotation;
    }

    void Update()
    {
        if (!isHolding) return;

        // Follow beside player
        //Vector3 targetPos = player.position + player.right * distanceFromPlayer;
        Vector3 targetPos =
        player.position
        - player.forward * forwordDistance  // move behind player
        + player.right * distanceFromPlayer;    // little side offset

        // Raycast from custom point
        if (rayPoint != null)
        {
            if (Physics.Raycast(rayPoint.position, Vector3.down, out RaycastHit hit, rayDistance, groundLayer))
            {
                targetPos.y = hit.point.y + groundOffset;
            }
        }

        // Smooth move
        transform.position = Vector3.Lerp(
            transform.position,
            targetPos,
            Time.deltaTime * followSpeed
        );
    }

    void OnDrawGizmos()
    {
        if (rayPoint == null) return;

        Gizmos.color = Color.green;
        Gizmos.DrawLine(
            rayPoint.position,
            rayPoint.position + Vector3.down * rayDistance
        );
    }
}