using UnityEngine;

public class AadharGetCollider : MonoBehaviour
{
    public AdvanceSecurityCheck advanceSecurityCheck;
    public AadharMaager aadharMaager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Aadhar"))
        {
            aadharMaager.triggerAadharObj.SetActive(true);
            other.gameObject.SetActive(false);
            advanceSecurityCheck.aadharCheck.SetInteger("AadharCheck", 2);

            for (int i = 0; i < aadharMaager.aadharObject.Length; i++)
            {
                aadharMaager.aadharObject[i].SetActive(true);
            }
        }
    }
}
