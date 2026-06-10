using UnityEngine;
using UnityEngine.InputSystem;

public class LeftControllerUI : MonoBehaviour
{
    public ShowPanel showPanel;

    void Update()
    {
        if (Gamepad.current != null)
        {
            if (Gamepad.current.buttonWest.wasPressedThisFrame)
            {
                showPanel.ShowUI();
            }
        }
    }
}