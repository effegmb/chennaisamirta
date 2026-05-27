using System.Collections;
using UnityEngine;

public class SlideDoorOpen : MonoBehaviour
{
    public Vector3 ROSPos;
    public Vector3 ROEPos;
    public Vector3 LOSPos;
    public Vector3 LOEPos;

    public GameObject rightSideObj;
    public GameObject leftSideObj;

    public float duration = 1.0f;


    public IEnumerator Open()
    {
        float time = 0;

        while (time < duration)
        {
            time += Time.deltaTime;
            float t = time / duration;

            rightSideObj.transform.localPosition = Vector3.Lerp(ROSPos, ROEPos, t);
            leftSideObj.transform.localPosition = Vector3.Lerp(LOSPos, LOEPos,t);
            yield return null;
        }

        rightSideObj.transform.localPosition = ROEPos;
        leftSideObj.transform.localPosition = LOEPos;
    }

    public IEnumerator Close()
    {
        float time = 0;

        while (time < duration)
        {
            time += Time.deltaTime;
            float t = time / duration;

            rightSideObj.transform.localPosition = Vector3.Lerp(ROEPos, ROSPos, t);
            leftSideObj.transform.localPosition = Vector3.Lerp(LOEPos, LOSPos, t);
            yield return null;
        }

        rightSideObj.transform.localPosition = ROSPos;
        leftSideObj.transform.localPosition = LOSPos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            StartCoroutine(Open());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            StartCoroutine(Close());
        }
    }
}
