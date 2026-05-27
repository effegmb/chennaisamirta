using UnityEngine;
using UnityEngine.Splines;

public class ShakeManage : MonoBehaviour
{
    public SplineAnimate splineAnim;

    public bool reached20 = false;
    public bool reached40 = false;

    public UIManager uIManager;

    // Update is called once per frame
    void Update()
    {
        if(!reached20 && splineAnim.NormalizedTime >= 0.1f)
        {
            reached20 = true;
        }

        if (!reached40 && splineAnim.NormalizedTime >= 0.4f)
        {
            reached40 = true;
            uIManager.shakeScriptObj.SetActive(false);
        }
    }
}
