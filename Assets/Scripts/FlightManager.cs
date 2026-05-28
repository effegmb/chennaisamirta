using UnityEngine;

public class FlightManager : MonoBehaviour
{
    public GameObject[] flymode;

    private void OnEnable()
    {
        if(GameManager.instance.flyMode == false)
        {
            for(int i = 0; i < flymode.Length; i++)
            {
                flymode[i].SetActive(false);
            }
        }
    }
}
