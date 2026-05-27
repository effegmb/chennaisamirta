using UnityEngine;

public class ArmyManScan : MonoBehaviour
{
    public Animator ArmyMan;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            ArmyMan.SetBool("Check", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            ArmyMan.SetBool("Check", false);
        }
    }
}
