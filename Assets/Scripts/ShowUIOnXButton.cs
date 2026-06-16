using UnityEngine;
using UnityEngine.XR;

public class ShowUIOnXButton : MonoBehaviour
{
    public GameObject instructionPanel;

    private InputDevice leftController;
    private bool previousButtonState = false;

    void Start()
    {
        leftController = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
    }

    void Update()
    {
        if (!leftController.isValid)
        {
            leftController = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
        }

        if (leftController.TryGetFeatureValue(CommonUsages.primaryButton, out bool currentButtonState))
        {
            // Toggle only when button is pressed (not while holding)
            if (currentButtonState && !previousButtonState)
            {
                instructionPanel.SetActive(!instructionPanel.activeSelf);
            }

            previousButtonState = currentButtonState;
        }
    }
}
