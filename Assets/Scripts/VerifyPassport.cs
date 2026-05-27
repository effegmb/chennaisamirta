using UnityEngine;

public class VerifyPassport : MonoBehaviour
{
    public GameObject passportVerifyUI;
    public bool firstTimePassportVerify;
    public Animator aadharCheck;
    public BoxCollider doorOpenBoxCollider;
    private void OnTriggerEnter(Collider other)
    {
        passportVerifyUI.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        passportVerifyUI.SetActive(false);
    }

    public void AadharCheck()
    {
        if (firstTimePassportVerify == false)
        {
            aadharCheck.SetBool("Verify", true);
            firstTimePassportVerify = true;
            doorOpenBoxCollider.isTrigger = true;
        }
    }
}
