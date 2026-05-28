using UnityEngine;

public class TicketGiveCollider : MonoBehaviour
{
    public TiketManager tiketManager;

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag("Player") && tiketManager.ticketGiveStart == false)
        {
            GameManager.instance.airportManager.ticketCounterArrow.SetActive(false);

            if (tiketManager.firstTimeOn == false)
            {
                tiketManager.ticketGiveCanvas.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            tiketManager.ticketGiveCanvas.SetActive(false);
        }
    }
}
