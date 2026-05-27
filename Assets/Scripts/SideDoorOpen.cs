using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Video;

public class SideDoorOpen : MonoBehaviour
{
    public GameObject rightDoor;
    public GameObject leftDoor;
    public Vector3 rightDoorStart;
    public Vector3 leftDoorStart;
    public Vector3 rightDoorEnd;
    public Vector3 leftDoorEnd;
    public bool doorIsOpen = false;
    public float duration = 1f;

    public VideoPlayer amirthaVideoPlayer;

    public IEnumerator OpenDoor()
    {
        float time = 0;
        while (time < duration)
        {
            time += Time.deltaTime;
            float t = time / duration;
            rightDoor.transform.localPosition = Vector3.Lerp(rightDoorStart, rightDoorEnd, t);
            leftDoor.transform.localPosition = Vector3.Lerp(leftDoorStart, leftDoorEnd, t);
            yield return null;
        }
        rightDoor.transform.localPosition = rightDoorEnd;
        leftDoor.transform.localPosition = leftDoorEnd;
    }

    public IEnumerator CloseDoor()
    {
        float time = 0;
        while (time < duration)
        {
            time += Time.deltaTime;
            float t = time / duration;
            rightDoor.transform.localPosition = Vector3.Lerp(rightDoorEnd, rightDoorStart, t);
            leftDoor.transform.localPosition = Vector3.Lerp(leftDoorEnd, leftDoorStart, t);
            yield return null;
        }
        rightDoor.transform.localPosition = rightDoorStart;
        leftDoor.transform.localPosition = leftDoorStart;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            StartCoroutine(OpenDoor());

            if (!amirthaVideoPlayer.isPlaying)
            {
                string path = Path.Combine(Application.streamingAssetsPath, "Amirtha.mp4");
                amirthaVideoPlayer.url = path;
                amirthaVideoPlayer.Play();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            StartCoroutine(CloseDoor());
        }
    }
}
