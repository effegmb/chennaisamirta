using UnityEngine;
using UnityEngine.SceneManagement;

public class AirPortManager : MonoBehaviour
{
    public void RomeMode()
    {
        GameManager.instance.flyMode = false;
        SceneManager.LoadScene(1);
    }
    public void LoadNextScene()
    {
        GameManager.instance.flyMode = true;
        SceneManager.LoadScene(1);
    }
}
