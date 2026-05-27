using UnityEngine;

public class BagSubmit : MonoBehaviour
{
    public GameObject hideBag;
    public GameObject showBag;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag("Bag"))
        {
            hideBag.SetActive(false);
            showBag.SetActive(true);   
        }
    }
}
