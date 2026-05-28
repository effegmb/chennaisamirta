using UnityEngine;

public class FlightManager : MonoBehaviour
{
    public GameObject[] flymode;

    public GameObject cockPitCanvas;

    private void OnEnable()
    {
        for (int i = 0; i < flymode.Length; i++)
        {
            flymode[i].SetActive(false);
        }
    }

    public void CockPit()
    {
        for (int i = 0; i < flymode.Length; i++)
        {
            flymode[i].SetActive(false);
        }
        cockPitCanvas.SetActive(true);
    }

    public void Fly()
    {
        for (int i = 0; i < flymode.Length; i++)
        {
            flymode[i].SetActive(true);
        }
    }
}
