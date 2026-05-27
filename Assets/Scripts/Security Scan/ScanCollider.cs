using UnityEngine;

public class ScanCollider : MonoBehaviour
{
    public ScanManager ScanManager;
    public GameObject scanUI;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            if (ScanManager.isScanned == false)
            {
                scanUI.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            scanUI.SetActive(false);
        }
    }
}
