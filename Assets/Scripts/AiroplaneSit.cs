using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Splines;
using UnityEngine.XR.Interaction.Toolkit.Locomotion.Turning;

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

    public UIManager uiManager;

    private void Start()
    {
        airoplaneAnimate.gameObject.transform.position = new Vector3(-71.3000031f, 22.6000004f, -135.5f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            //xrCameraRig.transform.rotation = Quaternion.Euler(0, 90, 0);

            seatBlockCollider.SetActive(true);
            newXRCameraRig.transform.localPosition = new Vector3(-2.82200003f, -2.53730965f, 15.1820002f);
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
