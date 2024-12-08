using System.Collections;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombiePrefab;  // The Zombie prefab
    public Transform[] spawnPoints;  // Array of spawn points
    public float spawnInterval = 3f; // Initial spawn interval
    public int zombiesPerRound = 5; // Initial number of zombies per round
    public Transform player; // Reference to the player's transform

    private int currentRound = 1;
    private int zombiesRemainingInRound;
    private float timeBetweenSpawns;
    private int zombiesAlive = 0; // Tracks how many zombies are still alive

    public int ZombiesAlive => zombiesAlive; // Property for zombies alive
    public int ZombiesRemainingInRound => zombiesRemainingInRound; // Zombies left to spawn in this round
    public int CurrentRound => currentRound; // Property for the current round

    void Start()
    {
        zombiesRemainingInRound = zombiesPerRound;
        timeBetweenSpawns = spawnInterval;
        StartCoroutine(SpawnZombies());
    }

    // Spawns zombies at the spawn points
    IEnumerator SpawnZombies()
    {
        while (true)
        {
            if (zombiesRemainingInRound > 0)
            {
                SpawnZombie();
                zombiesRemainingInRound--;
                zombiesAlive++;
                yield return new WaitForSeconds(timeBetweenSpawns);
            }
            else
            {
                // Check if all zombies are dead
                if (zombiesAlive <= 0) // All zombies are dead
                {
                    // Wait 5 seconds before starting the next round
                    yield return new WaitForSeconds(5f);

                    // Increase difficulty for the next round
                    currentRound++;
                    zombiesPerRound += 2;  // Increase zombies per round by 2
                    timeBetweenSpawns = Mathf.Max(1f, timeBetweenSpawns * 0.9f);  // Decrease spawn time (faster spawns)
                    zombiesRemainingInRound = zombiesPerRound;  // Reset for the next round
                }
                else
                {
                    // Wait a short time before rechecking
                    yield return new WaitForSeconds(1f);
                }
            }
        }
    }

    // Spawn a single zombie at a random spawn point
    void SpawnZombie()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];
        GameObject newZombie = Instantiate(zombiePrefab, spawnPoint.position, Quaternion.identity);

        // Assign the player as the target for the new zombie
        ZombieAI zombieAI = newZombie.GetComponent<ZombieAI>();
        if (zombieAI != null)
        {
            zombieAI.player = player;  // Set the player's transform to the zombie AI
        }

        // Assign this spawner to the enemy script in the zombie prefab
        Enemy enemy = newZombie.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.spawner = this; // Automatically link the spawner
        }
    }

    // Call this method when a zombie is killed to track the number of zombies remaining in the current round
    public void ZombieKilled()
    {
        zombiesAlive--;
    }
}
