using UnityEngine;
using UnityEngine.AI;

public class ZombieAI : MonoBehaviour
{
    public Transform player; // Reference to the player's Transform
    public float damage = 10f; // Damage dealt to the player
    public float attackCooldown = 1f; // Time between damage ticks
    private float nextAttackTime = 0f;

    public float stopDistance = 1.5f; // Distance to stop before reaching the player

    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        if (player == null)
        {
            Debug.LogError("Player Transform not assigned in ZombieAI script!");
        }
    }

    void Update()
    {
        if (player == null)
            return;

        // Calculate the distance to the player
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Move towards the player if outside the stop distance
        if (distanceToPlayer > stopDistance)
        {
            agent.isStopped = false; // Resume movement
            agent.SetDestination(player.position);
        }
        else
        {
            // Stop the zombie near the player
            agent.isStopped = true;

            // Attempt to attack the player
            TryAttackPlayer();
        }
    }

    private void TryAttackPlayer()
    {
        if (Time.time >= nextAttackTime)
        {
            nextAttackTime = Time.time + attackCooldown;

            // Assuming the player has a script to handle health
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
                Debug.Log("Zombie damaged the player!");
            }
        }
    }
}
