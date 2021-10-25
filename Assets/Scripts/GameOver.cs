using UnityEngine;

public class GameOver : MonoBehaviour
{
    private Level level;

    private void Start()
    {
        level = FindObjectOfType<Level>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            level.RestartLevel();
        }
    }
}