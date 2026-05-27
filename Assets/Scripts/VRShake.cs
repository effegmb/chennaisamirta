using UnityEngine;

public class VRShake : MonoBehaviour
{
    private Quaternion originalRot;
    public GameObject CameraOffset;
    [SerializeField] private float timer = 20;

    void Start()
    {
        originalRot = CameraOffset.transform.localRotation;
    }
    void Update()
    {
        if (timer > 0)
        {
            CameraOffset.transform.localRotation =
                Quaternion.Euler(0, 0, Mathf.Sin(Time.time * 20) * 0.5f);

            timer -= Time.deltaTime;
        }
        else
        {
            CameraOffset.transform.localRotation = originalRot;
        }
    }
}
