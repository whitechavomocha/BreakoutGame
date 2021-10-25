using UnityEngine;

public class Ball : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private GameObject paddle;

    [SerializeField] private float launchVelocityY = 6f;

    [Header("Hit SFXs")]
    [SerializeField] private AudioClip[] audioClips;

    [HideInInspector] public bool hasStarted = false;

    private Rigidbody2D rb2d;
    private AudioSource audioSource;
    private Touch theTouch;

    private Vector2 paddleToBallVector;

    // Start is called before the first frame update
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        paddleToBallVector = transform.position - paddle.transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        if (!hasStarted)
        {
            BallToPaddle();
            LaunchTheBall();
        }
    }

    private void BallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void LaunchTheBall()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Space))
        {
            hasStarted = true;
            rb2d.velocity = new Vector2(Random.Range(-2f, 2f), launchVelocityY);
        }
#endif

        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                theTouch = Input.GetTouch(i);
            }
            if (theTouch.phase == TouchPhase.Ended)
            {
                hasStarted = true;
                rb2d.velocity = new Vector2(Random.Range(-2f, 2f), launchVelocityY);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted)
        {
            audioSource.PlayOneShot(audioClips[Random.Range(0, audioClips.Length)]);
        }
    }
}