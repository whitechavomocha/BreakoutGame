using TMPro;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    [Range(0.1f, 10f)] public float gameSpeed = 1f;
    [Range(55f, 100f)] public int pointsPerBlock = 55;
    [HideInInspector] public int points = 0;

    [SerializeField] private TMP_Text Score;

    // Use this for initialization
    private void Start()
    {
        Score.text = "0";
        gameSpeed = 1f;
    }

    // Update is called once per frame
    private void Update()
    {
        Time.timeScale = gameSpeed;
        Score.text = points.ToString();
    }
}