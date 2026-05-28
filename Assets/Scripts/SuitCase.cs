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
    public Transform player; // Assign XR Rig / Camera
    public float followSpeed = 5f;
    public float distanceFromPlayer = 0.8f;

    [Header("Ground Check")]
    public float rayHeight = 2f;      // Ray start height
    public float rayDistance = 5f;    // Raycast distance
    public float groundOffset = 0.05f; // Small offset above ground
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

        // Target position beside player
        Vector3 targetPos = player.position + player.right * distanceFromPlayer;

        // Ground ray start point
        Vector3 rayStart = targetPos + Vector3.up * rayHeight;

        // Raycast downward
        if (Physics.Raycast(rayStart, Vector3.down, out RaycastHit hit, rayDistance, groundLayer))
        {
            // Set Y position based on ground hit
            targetPos.y = hit.point.y + groundOffset;
        }

        // Smooth movement
        transform.position = Vector3.Lerp(
            transform.position,
            targetPos,
            Time.deltaTime * followSpeed
        );
    }

    // Draw ray in Scene view
    void OnDrawGizmos()
    {
        if (player == null) return;

        Vector3 targetPos = player.position + player.right * distanceFromPlayer;
        Vector3 rayStart = targetPos + Vector3.up * rayHeight;

        Gizmos.color = Color.red;
        Gizmos.DrawLine(rayStart, rayStart + Vector3.down * rayDistance);
    }
}