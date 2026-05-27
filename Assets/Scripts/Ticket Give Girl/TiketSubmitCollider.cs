using UnityEngine;

public class TiketSubmitCollider : MonoBehaviour
{
    public TiketManager tiketManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Aadhar"))
        {
            tiketManager.tiketInGirlHand.SetActive(true);
            tiketManager.ticketGiveAnimator.SetInteger("TiketChecking", 2);
            tiketManager.getTiketObj.SetActive(false);
            tiketManager.ticketGetCollider.SetActive(false);
        }
    }
}
