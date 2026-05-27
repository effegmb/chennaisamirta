using UnityEngine;

public class VRMovementManager : MonoBehaviour
{

    public MonoBehaviour moveProvider;
    public MonoBehaviour turnProvider;

    private void OnEnable()
    {
        DisableMovement();
    }

    public void DisableMovement()
    {
        moveProvider.enabled = false;
        turnProvider.enabled = false;
    }

    public void EnableMovement()
    {
        moveProvider.enabled = true;
        turnProvider.enabled = true;
    }
}
