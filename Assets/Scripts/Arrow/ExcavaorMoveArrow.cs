using UnityEngine;

public class ExcavaorMoveArrow : ExcavatorMove
{

    public override void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            StartCoroutine(ExcavatorMoveTop());
            for (int i = 0; i < GameManager.instance.airportManager.stairsArrowPoint.Length; i++)
            {
                GameManager.instance.airportManager.stairsArrowPoint[i].SetActive(false);
            }
        }
    }
}
