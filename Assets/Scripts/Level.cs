using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    private int breakableBlocks;
    private GameStatus gameStatus;

    private void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
    }

    public void CountBreakableBlocks()
    {
        breakableBlocks++;
    }

    public void BlockDestroyed()
    {
        breakableBlocks--;
        gameStatus.points += gameStatus.pointsPerBlock;

        if (breakableBlocks <= 0)
        {
            NextLevel();
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void DoubleSpeed()
    {
        gameStatus.gameSpeed = 2f;
    }

    public void NormalSpeed()
    {
        gameStatus.gameSpeed = 1f;
    }
}