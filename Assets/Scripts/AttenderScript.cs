using UnityEngine;

public class AttenderScript : MonoBehaviour
{
    public Animator attendersAnim;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            attendersAnim.SetBool("Hello", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            attendersAnim.SetBool("Hello", false);
        }
    }
}
