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

        soketIntracterOff.SetActive(false);
        grabItracterOff.GetComponent<XRGrabInteractable>().enabled = false;

        yield return new WaitForSeconds(1);

        grabItracterOff.SetActive(false);
        onBagObject.SetActive(true);

        GameManager.instance.weightIsCheck = true;
       /* onBagObject.GetComponent<SuitCase>().enabled = true;
        onBagObject.GetComponent<XRGeneralGrabTransformer>().enabled = true;
        onBagObject.transform.position = new Vector3(-33.1699982f, 6.6500001f, 58.9300003f);*/
        //weightUI.text = number.ToString("F1");

        StopCoroutine(ValueIncrese());
    }
}
