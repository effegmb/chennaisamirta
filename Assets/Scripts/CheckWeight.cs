using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.XR.Interaction.Toolkit.Transformers;

public class CheckWeight : MonoBehaviour
{
    public TMP_Text weightUI;
    float number;
    public GameObject grabItracterOff;
    public GameObject soketIntracterOff;

    public GameObject onBagObject;

    public void RandomWeightEnter()
    {
        number = Random.Range(19, 21);
        StartCoroutine(ValueIncrese());
    }

    public IEnumerator ValueIncrese()
    {
        float currentNummber = 0;

        while (currentNummber < number)
        {
            currentNummber = Mathf.MoveTowards(
            currentNummber,
            number,
            Time.deltaTime * 10
        );
            weightUI.text = currentNummber.ToString("F1");
            yield return null; 
        }

        grabItracterOff.GetComponent<XRGrabInteractable>().enabled = false;

        yield return new WaitForSeconds(1);

        grabItracterOff.SetActive(false);
        onBagObject.SetActive(true);
        GameManager.instance.airportManager.ticketCounterArrow.SetActive(true);
        GameManager.instance.airportManager.ticketCounterCollider.SetActive(true);

        GameManager.instance.weightIsCheck = true;
        soketIntracterOff.SetActive(false);
        StopCoroutine(ValueIncrese());
    }
}
