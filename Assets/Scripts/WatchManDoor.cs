using System.Collections;
using UnityEngine;

public class WatchManDoor : MonoBehaviour
{
    public GameObject rightDoor;
    public GameObject leftDoor;
    public Vector3 rightDoorStart;
    public Vector3 leftDoorStart;
    public Vector3 rightDoorEnd;
    public Vector3 leftDoorEnd;
    public bool doorIsOpen = false;
    public float duration = 1f;

    public IEnumerator OpenDoor()
    {
        float time = 0;
        while (time < duration)
        {
            time += Time.deltaTime;
            float t = time / duration;
            rightDoor.transform.position = Vector3.Lerp(rightDoorStart, rightDoorEnd, t);
            leftDoor.transform.position = Vector3.Lerp(leftDoorStart, leftDoorEnd, t);
            yield return null;
        }
        rightDoor.transform.position = rightDoorEnd;
        leftDoor.transform.position = leftDoorEnd;
    }

    public IEnumerator CloseDoor()
    {
        float time = 0;
        while (time < duration)
        {
            time += Time.deltaTime;
            float t = time / duration;
            rightDoor.transform.position = Vector3.Lerp(rightDoorEnd, rightDoorStart, t);
            leftDoor.transform.position = Vector3.Lerp(leftDoorEnd, leftDoorStart, t);
            yield return null;
        }
        rightDoor.transform.position = rightDoorStart;
        leftDoor.transform.position = leftDoorStart;
    }
}
