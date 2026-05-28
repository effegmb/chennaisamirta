using Unity.VisualScripting.InputSystem;
using UnityEngine;
using UnityEngine.Splines;

public class MoveSplineComplete : MonoBehaviour
{
    public SplineAnimate splineAnimate;
    public ShakeManage shakeManager;

    public GameObject UICanvas;
    public bool firstTime = false;
    public GameObject CompleteCanvas;
    private void OnEnable()
    {
        splineAnimate.Completed += OnSplineComplete;
    }

    private void OnDisable()
    {
        splineAnimate.Completed -= OnSplineComplete;
    }

    private void OnSplineComplete()
    {
        if (firstTime == false)
        {
            firstTime = true;
            Debug.Log("Spline Animation Completed!");
            UICanvas.SetActive(true);
            shakeManager.enabled = true;
        }
        else
        {
            CompleteCanvas.SetActive(true);
        }
    }
}
