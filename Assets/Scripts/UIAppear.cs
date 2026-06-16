using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAppear : MonoBehaviour
{
    public GameObject[] panels;


    void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            foreach (GameObject panel in panels)
            {
                panel.SetActive(true);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            foreach (GameObject panel in panels)
            {
                panel.SetActive(false);
            }
        }
    }
}