using UnityEngine;

public class VanakkamGirl : MonoBehaviour
{
    public Animator vanakkamGirlAnimator;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            vanakkamGirlAnimator.SetBool("Near", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            vanakkamGirlAnimator.SetBool("Near", false);
        }
    }
}
