using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public AirportManager airportManager;

    [Header("Objects")]
    public GameObject[] stairsBlockColliderObj;
    public GameObject excavatorMove;

    public bool weightIsCheck;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
