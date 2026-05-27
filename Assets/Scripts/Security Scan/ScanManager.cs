using UnityEngine;

public class ScanManager : MonoBehaviour
{
    public Animator scanAnimator;
    public bool isScanned = false;

    public void ScanAnimationStart()
    {
        scanAnimator.SetBool("Scan",true);
    }
    
    public void ScanIsComplete()
    {
        scanAnimator.SetBool("Scan", false);
        isScanned = true;
    }
}