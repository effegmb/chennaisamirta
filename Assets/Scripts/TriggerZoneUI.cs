using UnityEngine;

public class TriggerZoneUI : MonoBehaviour
{
    public ShowPanel uiManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uiManager.ShowUI();
        }
    }
}