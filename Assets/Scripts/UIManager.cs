using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Filtering;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class UIManager : MonoBehaviour
{
    public GameObject beltUICanvas;
    

    public XRSocketInteractor socket1;
    public XRSocketInteractor socket2;

    private bool firstPlaced = false;
    private bool secondPlaced = false;

    public Transform leftSeatBelt;
    public Transform rightSeatBelt;
    public Vector3 rightStartPos;
    public Vector3 leftStartPos;

    [Header("Next Animation Character")]
    public GameObject beltAnimation;
    public GameObject nextAnimation;

    public GameObject shakeScriptObj;
    private bool nextStart = false;

    private void Start()
    {
        leftStartPos = leftSeatBelt.position;
        rightStartPos = rightSeatBelt.position;
    }

    private void OnEnable()
    {
        socket1.selectEntered.AddListener(OnFirstPlaced);
        socket2.selectEntered.AddListener(OnSecondPlaced);
    }

    private void OnDisable()
    {
        socket1.selectEntered.RemoveListener(OnFirstPlaced);
        socket2.selectEntered.RemoveListener(OnSecondPlaced);
    }

    private void OnFirstPlaced(SelectEnterEventArgs args)
    {
        GameObject obj = args.interactableObject.transform.gameObject;

        if (obj.CompareTag("Belt"))
        {
            firstPlaced = true;
            CheckBothPlaced();
        }
    }

    private void OnSecondPlaced(SelectEnterEventArgs args)
    {
        GameObject obj = args.interactableObject.transform.gameObject;

        if (obj.CompareTag("Key"))
        {
            secondPlaced = true;
            CheckBothPlaced();
        }
    }

    private void CheckBothPlaced()
    {
        if (firstPlaced && secondPlaced)
        {
            Debug.Log("Both objects placed!");

            if(nextStart == false)
            {
                nextStart = true;
                // Move to next part here
                NextPart();
            }
        }
    }

    private void NextPart()
    {
        beltUICanvas.SetActive(false);
        Debug.Log("Next Part Started");

        beltAnimation.SetActive(false);
        nextAnimation.SetActive(true);

        // Example:
        // nextPanel.SetActive(true);
        // door.Open();
        // SceneManager.LoadScene(...);
    }

    public void firstSeatBeltPlaced()
    {
        if (!firstPlaced)
        {
            leftSeatBelt.position = leftStartPos;
        }
    }

    public void SecoundBeltPlaced()
    {
        if (!secondPlaced)
        {
            rightSeatBelt.position = rightStartPos;
        }
    }
}
