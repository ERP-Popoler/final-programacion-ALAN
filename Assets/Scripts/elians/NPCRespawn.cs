using UnityEngine;
using UnityEngine.AI;

public class NPCRespawn : MonoBehaviour
{
    public GameObject npcPrefab;
    public Transform[] spawnPoints;
    public float respawnTime = 5f;

    private void Start()
    {
        SpawnNPC();
    }

    void SpawnNPC()
    {
        Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject npc = Instantiate(npcPrefab, randomPoint.position, Quaternion.identity);

        // Asignar destino
        NavMeshAgent agent = npc.GetComponent<NavMeshAgent>();
        if (agent != null)
        {
            Vector3 randomDestination = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
            agent.SetDestination(randomDestination);
        }

        // Volver a spawnear cuando muera
        StartCoroutine(RespawnTimer());
    }

    System.Collections.IEnumerator RespawnTimer()
    {
        yield return new WaitForSeconds(respawnTime);
        SpawnNPC();
    }
}
