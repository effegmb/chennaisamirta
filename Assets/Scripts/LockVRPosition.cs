using UnityEngine;

public class LockVRPosition : MonoBehaviour
{
    [SerializeField] private Vector3 startPos;


    private void Start()
    {
        startPos = transform.position;
    }

    void LateUpdate()
    {
        transform.position = startPos;
    }
}
