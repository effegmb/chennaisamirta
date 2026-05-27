using UnityEngine;

public class TicketGiveCollider : MonoBehaviour
{
    public TiketManager tiketManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
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
