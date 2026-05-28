using UnityEngine;

public class TiketManagerTwo : TiketManager
{
    public override void GotoIdle()
    {
        GameManager.instance.airportManager.checkArmyManCollider.SetActive(true);
        firstTimeOn = true;
        ticketGiveAnimator.SetInteger("TiketChecking", 0);
    }
}
