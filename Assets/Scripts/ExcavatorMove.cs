using JetBrains.Annotations;
using System.Collections;
using UnityEngine;

public class ExcavatorMove : MonoBehaviour
{
    public Transform startpos;
    public Transform endpos;
    public float duration = 2;
    public GameObject player;
    public GameObject lastBoxColliderOn;

    public IEnumerator ExcavatorMoveTop()
    {
        float time = 0;
        while (time < duration)
        {
            time += Time.deltaTime;
            float t = time / duration;

            player.transform.position = Vector3.Lerp(startpos.position, endpos.position, t);

            yield return null;
        }

        player.transform.position = endpos.position;
        lastBoxColliderOn.SetActive(true);
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            StartCoroutine(ExcavatorMoveTop());
        }
    }
}
