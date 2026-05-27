using Unity.VisualScripting.InputSystem;
using UnityEngine;
using UnityEngine.Splines;

public class MoveSplineComplete : MonoBehaviour
{
    public SplineAnimate splineAnimate;
    public ShakeManage shakeManager;

    public GameObject UICanvas;
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
        Debug.Log("Spline Animation Completed!");
        UICanvas.SetActive(true);
        shakeManager.enabled = true;
    }
}
