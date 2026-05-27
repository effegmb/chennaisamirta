using UnityEngine;
using UnityEngine.XR;

public class VRResolution : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        XRSettings.eyeTextureResolutionScale = 1.2f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
