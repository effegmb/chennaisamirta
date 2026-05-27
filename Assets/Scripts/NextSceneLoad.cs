using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneLoad : MonoBehaviour
{
    public GameObject Canvas;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            Canvas.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            Canvas.SetActive(false);
        }
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(1);
    }
}
