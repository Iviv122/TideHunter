using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] InputManager manager;
    [SerializeField] Rigidbody rb;
    [SerializeField] Transform orientation;
    [SerializeField] float MoveSpeed;

    [Header("Sounds")]
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] footSteps;
    private CountdownTimer soundTimer;
    [SerializeField] private float stepDelay = 0.45f;
    private Vector3 dir;
    void Awake()
    {
        manager.Move += Move;
        soundTimer = new(stepDelay);
        soundTimer.OnTimerStop = () =>
        {
            soundTimer.Reset(stepDelay);
            soundTimer.Start();
            PlaySound();
        };
        soundTimer.Start();
    }
    void Move(Vector2 dir)
    {
        this.dir = dir.normalized;
    }
    private void FixedUpdate()
    {
        Vector3 actualdir = (dir.y * orientation.forward + dir.x * orientation.right).normalized;


        rb.linearVelocity = new Vector3(actualdir.x, 0, actualdir.z).normalized  * MoveSpeed +new Vector3(0, rb.linearVelocity.y, 0);
        if (rb.linearVelocity != Vector3.zero)
        {
            soundTimer.Tick(Time.deltaTime);
        }
    }
    void PlaySound()
    {
        audioSource.PlayOneShot(footSteps[Random.Range(0, footSteps.Length)]);
    }
}
