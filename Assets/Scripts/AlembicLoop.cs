using System.Reflection;
using UnityEngine;

public class AlembicLoop : MonoBehaviour
{
   [SerializeField] private Component alembicPlayer;
    private PropertyInfo timeProperty;

    public float duration = 0.791666f;
    public float speed = 1f;

    private float currentTime;

    void Start()
    {
        alembicPlayer = GetComponent("AlembicStreamPlayer");

        if (alembicPlayer != null)
        {
            timeProperty = alembicPlayer.GetType().GetProperty("CurrentTime");
        }
    }

    void Update()
    {
        if (alembicPlayer == null || timeProperty == null)
            return;

        currentTime += Time.deltaTime * speed;

        if (currentTime > duration)
            currentTime = 0f;

        timeProperty.SetValue(alembicPlayer, currentTime);
    }
}
