using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class BagScan : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public GameObject startObj;
    public GameObject endObj;

    [SerializeField] float duration = 5f;

    private bool isRunning = false;

    private XRGrabInteractable grab;
    private BoxCollider col;

    private void Start()
    {
        if (startObj != null)
        {
            grab = startObj.GetComponent<XRGrabInteractable>();
            col = startObj.GetComponent<BoxCollider>();
        }
    }

    public IEnumerator BagScanEnter()
    {
        if (startObj == null) yield break;

        // Disable interaction
        if (grab != null) grab.enabled = false;
        if (col != null) col.enabled = false;

        // Set rotation once
        startObj.transform.rotation = Quaternion.Euler(-180, 0, 0);

        float time = 0;

        while (time < duration)
        {
            time += Time.deltaTime;

            float t = time / duration;

            // Move object
            startObj.transform.position = Vector3.Lerp(startPoint.position, endPoint.position, t);

            yield return null;
        }

        // Final position fix
        startObj.transform.position = endPoint.position;

        // Switch objects
        startObj.SetActive(false);
        endObj.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bag") && !isRunning)
        {
            isRunning = true;
            StartCoroutine(BagScanEnter());
        }
    }
}