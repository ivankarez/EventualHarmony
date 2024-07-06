using UnityEngine;

public class SceneManager : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private int agentCount = 50;
    [SerializeField] private float mutationStdDev = 0.1f;

    [Header("Dependencies")]
    [SerializeField] private Agent agentPrefab;
    [SerializeField] private PlayingField playingField;
    [SerializeField] private NoteStatisticsUi noteStatisticsUi;

    private void Start()
    {
        Application.targetFrameRate = 60;

        agentPrefab.gameObject.SetActive(false);
        for (int i = 0; i < agentCount; i++)
        {
            SpawnAgent(Random.Range(0, 12) / 12f);
        }
    }

    private void SpawnAgent(float dna)
    {
        var agent = Instantiate(agentPrefab);
        agent.transform.position = playingField.GetRandomPosition();
        agent.gameObject.SetActive(true);
        agent.Dna = dna;
        agent.OnEnergyDepleted.AddListener(() => OnAgentEnergyDepleted(agent));
        noteStatisticsUi.IncrementAliveNoteCount(agent.Note);
    }

    private void OnAgentEnergyDepleted(Agent agent)
    {
        noteStatisticsUi.DecrementAliveNoteCount(Mathf.RoundToInt(agent.Note));
        var mutatedDna = agent.Dna + Utils.NormalRandom(0f, mutationStdDev);
        SpawnAgent(mutatedDna);
        Destroy(agent.gameObject);
    }
}
