using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Splines;
using UnityEngine.XR.Interaction.Toolkit.Locomotion.Turning;
using Unity.XR.CoreUtils;

public class AiroplaneSit : MonoBehaviour
{
    public GameObject xrCameraRig;

    public GameObject newXRCameraRig;
    public GameObject[] arrowIndication;
    //public LockVRPosition lookVRPosition;

    public GameObject seatBeltCharacter;
    public GameObject seatBeltCharacterUI;

    [Header("Seat Belt")]
    public GameObject[] SeatBeltObjs;
    public GameObject seatBlockCollider;

    [Header("Spline Animators")]
    public SplineAnimate airoplaneAnimate;
    public SplineContainer airoplanePosition;
    public SplineContainer flyplaneContainer;

    public XROrigin xrOrigin;
    public GameObject seatPos;

    public UIManager uiManager;

    private void Start()
    {
        //airoplaneAnimate.gameObject.transform.position = new Vector3(-2.90400004f, -2.50099993f, 15.1409998f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            //xrCameraRig.transform.rotation = Quaternion.Euler(0, 90, 0);

            seatBlockCollider.SetActive(true);
            newXRCameraRig.transform.position = seatPos.transform.position;
            xrOrigin.MoveCameraToWorldLocation(seatPos.transform.position);
            xrCameraRig.SetActive(false);
            newXRCameraRig.SetActive(true);

            seatBeltCharacter.SetActive(true);
            seatBeltCharacterUI.SetActive(true);

            //continuousTurnProvider.enableTurnLeftRight = false;
            //continuousTurnProvider.enableTurnAround = false;

            for(int i = 0;i < arrowIndication.Length; i++)
            {
                arrowIndication[i].SetActive(false);
            }
            //lookVRPosition.enabled = true;
        } 
    }

    public void SeatBeltAnimationStart()
    {
        /*seatBeltCharacter.GetComponent<Animator>().SetBool("SeatBelt", true);*/

        for(int i = 0;i < SeatBeltObjs.Length; i++)
        {
            SeatBeltObjs[i].SetActive(true);
        }
    }

    public void AiroPlanePositionSet()
    {
        airoplaneAnimate.Container = airoplanePosition;
        airoplaneAnimate.Duration = 50;
        airoplaneAnimate.Restart(true);

        //airoplaneAnimate.Play();
    }

    public void AiroPlaneFly()
    {
        uiManager.shakeScriptObj.SetActive(true);
        airoplaneAnimate.Container = flyplaneContainer;
        airoplaneAnimate.Duration = 100;
        //airoplaneAnimate.Play();
        airoplaneAnimate.Restart(true);
    }
}
