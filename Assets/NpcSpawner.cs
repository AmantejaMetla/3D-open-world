using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcSpawner : MonoBehaviour
{
    public GameObject npcPrefab;      // Prefab for NPC
    public int npcCount = 10;         // Number of NPCs to spawn
    public float spawnRadius = 20f;   // Radius around the player to spawn NPCs
    public LayerMask groundLayer;     // Terrain layer mask
    public Transform player;          // Reference to the player

    void Start()
    {
        SpawnNPCs();
    }

    void SpawnNPCs()
    {
        for (int i = 0; i < npcCount; i++)
        {
            Vector3 spawnPosition = GetRandomSpawnPositionAroundPlayer();
            Instantiate(npcPrefab, spawnPosition, Quaternion.identity);
        }
    }

    Vector3 GetRandomSpawnPositionAroundPlayer()
    {
        // Generate a random position around the player within the spawnRadius
        Vector2 randomCircle = Random.insideUnitCircle * spawnRadius;
        Vector3 randomPosition = new Vector3(
            player.position.x + randomCircle.x,
            player.position.y + 10, // Start raycast from above the ground
            player.position.z + randomCircle.y
        );

        // Use Raycast to adjust position to the ground
        RaycastHit hit;
        if (Physics.Raycast(randomPosition, Vector3.down, out hit, 20f, groundLayer))
        {
            return new Vector3(hit.point.x, hit.point.y, hit.point.z);
        }

        // Fallback position in case Raycast fails
        return player.position;
    }

    void OnDrawGizmos()
    {
        // Visualize the spawn radius around the player
        if (player != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(player.position, spawnRadius);
        }
    }
}

