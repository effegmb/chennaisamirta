using UnityEngine;

public class TicketGiveColliderTwo : TicketGiveCollider
{
    public override void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag("Player") && tiketManager.ticketGiveStart == false)
        {

            if (tiketManager.firstTimeOn == false)
            {
                tiketManager.ticketGiveCanvas.SetActive(true);
            }
        }
    }
}
