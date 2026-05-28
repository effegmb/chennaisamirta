using UnityEngine;

public class TiketManager : MonoBehaviour
{
    public Animator ticketGiveAnimator;
    public bool firstTimeOn = false;
    public GameObject ticketGiveCanvas;

    public GameObject getTiketObj;
    public GameObject ticketGetCollider;

    public GameObject tiketInGirlHand;

    public GameObject tiketHandOverObj;
    public bool ticketGiveStart = false;

    public void StartCheckTiket()
    {
        ticketGiveStart = true;
        ticketGiveCanvas.SetActive(false);
        ticketGiveAnimator.SetInteger("TiketChecking", 1);
    }

    public void TiketGetEvent()
    {
        getTiketObj.SetActive(true);
        ticketGetCollider.SetActive(true);
    }

    public void TicketHandOver()
    {
        tiketHandOverObj.SetActive(true);
    }

    public void TiketGetBackCollider()
    {
        tiketHandOverObj.SetActive(false);
        tiketInGirlHand.SetActive(false);
        ticketGiveAnimator.SetInteger("TiketChecking", 3);
    }

    public virtual void GotoIdle()
    {
        GameManager.instance.airportManager.ticketCounterBagSoket.SetActive(true);
        GameManager.instance.airportManager.versionTwoBag.SetActive(false);
        GameManager.instance.airportManager.newSubmitBag.SetActive(true);
        firstTimeOn = true;
        ticketGiveAnimator.SetInteger("TiketChecking", 0);
    }
}
