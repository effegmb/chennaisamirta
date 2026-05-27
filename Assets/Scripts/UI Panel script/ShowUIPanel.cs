using UnityEngine;
using System.Collections;

public class ShowUIPanel : MonoBehaviour
{
    public GameObject uiPanel;   // Assign your UI Panel
    public float displayTime = 5f; // Seconds to stay visible

    private Coroutine hideCoroutine;

    private void Start()
    {
        uiPanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            uiPanel.SetActive(true);

            // Restart timer if player enters again
            if (hideCoroutine != null)
            {
                StopCoroutine(hideCoroutine);
            }

            hideCoroutine = StartCoroutine(HidePanelAfterTime());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            uiPanel.SetActive(false);
        }
    }

    IEnumerator HidePanelAfterTime()
    {
        yield return new WaitForSeconds(displayTime);

        uiPanel.SetActive(false);
    }
}