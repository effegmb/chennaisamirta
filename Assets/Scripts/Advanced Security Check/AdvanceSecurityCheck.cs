using UnityEngine;

public class AdvanceSecurityCheck : MonoBehaviour
{
    public GameObject passportVerifyUI;
    public bool firstTimePassportVerify;
    public Animator aadharCheck;
    public BoxCollider doorOpenBoxCollider;
    public bool animationIsTriggered = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag("Player") /*&& !passportVerifyUI.activeInHierarchy*/ && animationIsTriggered == false)
        {
            passportVerifyUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            passportVerifyUI.SetActive(false);
        }
    }

    public void AadharCheck()
    {
        if (firstTimePassportVerify == false)
        {
            animationIsTriggered = true;
            passportVerifyUI.SetActive(false);
            Debug.Log(aadharCheck.GetInteger("AadharCheck"));
            aadharCheck.SetInteger("AadharCheck", 1);
        }


        firstTimePassportVerify = true;
        doorOpenBoxCollider.isTrigger = true;
    }
}
