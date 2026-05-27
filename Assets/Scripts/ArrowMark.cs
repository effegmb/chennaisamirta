using UnityEngine;

public class ArrowMark : MonoBehaviour
{
    public Vector3 startPos;
    public Vector3 endPos;
    public float speed = 2f;

    // Update is called once per frame
    void Update()
    {
        float t = Mathf.PingPong(Time.time * speed, 1);
        transform.localPosition = Vector3.Lerp(startPos, endPos, t);
    }
}
