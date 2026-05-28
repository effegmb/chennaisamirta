using UnityEngine;

public class FullBodyScanner : MonoBehaviour
{
    public AudioClip beepAudio;
    public AudioSource fullBodyMechineAS;

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            fullBodyMechineAS.PlayOneShot(beepAudio);
        }
    }
}
