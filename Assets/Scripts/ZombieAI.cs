using UnityEngine;
using UnityEngine.AI;

public class ZombieAI : MonoBehaviour
{
    public Transform player; // Reference to the player's Transform
    public float damage = 10f; // Damage dealt to the player
    public float attackCooldown = 1f; // Time between damage ticks
    private float nextAttackTime = 0f;

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

        // Always move toward the player
        agent.SetDestination(player.position);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.CompareTag("Player") && Time.time >= nextAttackTime)
        {
            nextAttackTime = Time.time + attackCooldown;

            // Assuming the player has a script to handle health
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
                Debug.Log("Zombie damaged the player!");
            }
        }
    }
}
