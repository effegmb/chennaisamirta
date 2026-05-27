using UnityEngine;

public class AadharMaager : MonoBehaviour
{
    public AdvanceSecurityCheck advanceSecurityCheck;
    public GameObject aadharGetColliderOn;
    public GameObject[] aadharObject;
    public GameObject triggerAadharObj;
    public GameObject aadharGiveBackCollider;

    public void GetAadharEnd()
    {
        triggerAadharObj.SetActive(true);
        aadharGetColliderOn.SetActive(true);
    }

    public void AadharSign()
    {
        for (int i = 0; i < aadharObject.Length; i++)
        {
            aadharObject[i].SetActive(false);
        }
    }

    public void AadharGiveBack()
    {
        aadharGiveBackCollider.SetActive(true);
        for (int i = 0; i < aadharObject.Length; i++)
        {
            aadharObject[i].SetActive(true);
        }
        advanceSecurityCheck.firstTimePassportVerify = true;
    }

    public void GotoIdle()
    {
        for (int i = 0; i < aadharObject.Length; i++)
        {
            aadharObject[i].SetActive(false);
        }
        advanceSecurityCheck.aadharCheck.SetInteger("AadharCheck", 3);
        aadharGiveBackCollider.SetActive(false);

        advanceSecurityCheck.doorOpenBoxCollider.isTrigger = true;
        GameManager.instance.airportManager.weightMechineArrow.SetActive(true);
    }

    public void AadharIsChecked()
    {
        if (advanceSecurityCheck.firstTimePassportVerify == true)
        {
            advanceSecurityCheck.aadharCheck.SetInteger("AadharCheck", 0);
        }
    }
}
