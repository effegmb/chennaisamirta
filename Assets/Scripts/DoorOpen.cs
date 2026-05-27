using System.Collections;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public Quaternion startRotation;
    public Quaternion endRotation;

    public bool opened = false;
    public float duration = 1.0f;
    public bool doorCurrentMoving = false;

    public void DoorOpenButton()
    {
        if (doorCurrentMoving) return;

        if (opened)
        {
            StartCoroutine(DoorClose());
        }
        else
        {
            StartCoroutine(DoorOpening());
        }
    }

    public IEnumerator DoorOpening()
    {
        doorCurrentMoving = true;

        float time = 0f;
        while (time < duration)
        {
            time += Time.deltaTime;
            float t = time / duration;

            transform.localRotation = Quaternion.Lerp(startRotation, endRotation, t);
            yield return null;
        }

        transform.localRotation = endRotation;
        opened = true;
        doorCurrentMoving = false;
    }

    public IEnumerator DoorClose()
    {
        doorCurrentMoving = true;

        float time = 0f;
        while (time < duration)
        {
            time += Time.deltaTime;
            float t = time / duration;

            transform.localRotation = Quaternion.Lerp(endRotation, startRotation, t);
            yield return null;
        }

        transform.localRotation = startRotation;
        opened = false;
        doorCurrentMoving = false;
    }
}