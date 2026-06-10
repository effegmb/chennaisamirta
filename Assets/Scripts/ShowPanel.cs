using UnityEngine;

public class ShowPanel : MonoBehaviour
{
    public GameObject uiPanel;

    private void Start()
    {
        uiPanel.SetActive(false);
    }

    public void ShowUI()
    {
        uiPanel.SetActive(true);
    }

    public void HideUI()
    {
        uiPanel.SetActive(false);
    }
}