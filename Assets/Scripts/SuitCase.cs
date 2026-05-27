using UnityEngine;
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
