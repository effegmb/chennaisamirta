using UnityEngine;
using UnityEngine.Splines;

public class CarStop : MonoBehaviour
{
    [SerializeField] private SplineAnimate carMovement; // Drag your spline movement script here in Inspector

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            if (carMovement != null)
                carMovement.Pause(); // Stop movement
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            if (carMovement != null)
                carMovement.Play();   // Resume movement
        }
    }
}