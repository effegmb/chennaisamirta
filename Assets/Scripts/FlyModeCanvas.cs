using UnityEngine;

public class FlyModeCanvas : MonoBehaviour
{
    public GameObject flymodeCanvas;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            flymodeCanvas.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            flymodeCanvas.SetActive(false);
        }
    }
}