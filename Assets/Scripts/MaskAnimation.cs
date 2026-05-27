using UnityEngine;

public class MaskAnimation : MonoBehaviour
{
    public GameObject MaskAnimationObj;
    public GameObject pharashootAnimation;

    public GameObject NextUICanvas;
    public void NextAnimation()
    {
        MaskAnimationObj.SetActive(false);
        pharashootAnimation.SetActive(true);
    }

    public void GameCompleted()
    {
        pharashootAnimation.SetActive(false);
        NextUICanvas.SetActive(true);
    }
}
