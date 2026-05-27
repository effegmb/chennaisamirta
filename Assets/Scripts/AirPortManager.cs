using UnityEngine;
using UnityEngine.SceneManagement;

public class AirPortManager : MonoBehaviour
{
   public void LoadNextScene()
    {
        SceneManager.LoadScene(1);
    }
}
