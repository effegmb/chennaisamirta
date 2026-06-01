using UnityEngine;

public class ScanManager : MonoBehaviour
{
    public Animator scanAnimator;
    public bool isScanned = false;
    public ScanCollider scanCollider;
    public GameObject arrowObj;

    public void ScanAnimationStart()
    {
        if (isScanned == false)
        {
            scanCollider.scanUI.SetActive(false);
            scanAnimator.SetBool("Scan", true);
        }
    }
    
    public void ScanIsComplete()
    {
        GameManager.instance.airportManager.flymodeCollider.gameObject.SetActive(true);
        scanAnimator.SetBool("Scan", false);
        isScanned = true;
        arrowObj.SetActive(true);
    }
}