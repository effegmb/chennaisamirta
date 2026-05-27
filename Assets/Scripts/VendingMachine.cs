using UnityEngine;

public class VendingMachine : MonoBehaviour
{
    public Transform spawnPoints;
    public GameObject colaPrefab;

    GameObject spawnObj;
    public void SpawnCola()
    {
        if(spawnObj == null)
        {
            spawnObj = Instantiate(colaPrefab, spawnPoints.position, Quaternion.identity);
        }
    }
}
