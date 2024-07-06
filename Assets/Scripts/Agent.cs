using UnityEngine;
using UnityEngine.Events;

public class Agent : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float pushForce = 1f;
    [SerializeField] private float pushIntervalMean = 1f;
    [SerializeField] private float pushIntervalStdDev = 0.1f;
    [SerializeField] private float initialEnergy = 100f;
    [SerializeField] private float minimumEnergy = 50f;

    [Header("Dependencies")]
    [SerializeField] private Rigidbody2D agentRigidbody;
    [SerializeField] private PlayingField playingField;
    [SerializeField] private ColorScheme colorScheme;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private ScoringSystem scoringSystem;
    [SerializeField] private AgentAudioSourcePool audioSourcePool;
    [SerializeField] private NoteIndicatorPool noteIndicatorPool;

    public float Dna
    {
        get => dna;
        set
        {
            dna = value;
            Note = Mathf.FloorToInt(dna * 12) % 12;
            while (Note < 0)
            {
                Note += 12;
            }
            spriteRenderer.color = colorScheme.Colors[Note];
        }
    }
    public int Note
    {
        get => note;
        private set
        {
            note = value;
        }
    }
    public float Energy
    {
        get => energy;
        set
        {
            energy = value;
            transform.localScale = Vector3.one * Mathf.Clamp01(energy / initialEnergy);
        }
    }
    public UnityEvent OnEnergyDepleted { get; } = new UnityEvent();

    private Vector3 waypoint;
    private float nextPushTime;
    private Vector3 wapointDirection;
    private int note;
    private float energy;
    private float dna;

    private void Start()
    {
        ChooseNewWaypoint();
        CalculateNextPushTime();
        Energy = initialEnergy;
    }

    private void Update()
    {
        wapointDirection = waypoint - transform.position;
        var distance = wapointDirection.magnitude;
        if (distance < 0.5f)
        {
            ChooseNewWaypoint();
        }
    }

    private void FixedUpdate()
    {
        if (Time.realtimeSinceStartup > nextPushTime)
        {
            var force = wapointDirection.normalized * pushForce;
            agentRigidbody.AddForce(force, ForceMode2D.Impulse);
            CalculateNextPushTime();
        }
    }

    private void ChooseNewWaypoint()
    {
        waypoint = playingField.GetRandomPosition();
    }

    private void CalculateNextPushTime()
    {
        nextPushTime = Time.realtimeSinceStartup + Utils.NormalRandom(pushIntervalMean, pushIntervalStdDev);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Agent>(out var otherAgent))
        {
            var score = scoringSystem.CalculateScore(Note, otherAgent.Note);
            noteIndicatorPool.ShowNoteIndicator(score, transform.position);
            Energy += score;
            audioSourcePool.PlayNote(Note,
                Energy / initialEnergy,
                transform.position.x / playingField.PlayingFieldSizeX);

            if (Energy <= minimumEnergy)
            {
                OnEnergyDepleted.Invoke();
            }
        }
    }
}
