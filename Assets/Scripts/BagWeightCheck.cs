using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Transformers;

public class BagWeightCheck : MonoBehaviour
{
    public GameObject objectPlaceCollider;
    public GameObject newObjectOn;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bag"))
        {
            GameManager.instance.airportManager.weightMechineArrow.SetActive(false);
            other.gameObject.GetComponent<SuitCase>().enabled = false;
            other.gameObject.GetComponent<XRGeneralGrabTransformer>().enabled = false;
            objectPlaceCollider.SetActive(true);
            newObjectOn.SetActive(true);
            other.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }   
    }
}
