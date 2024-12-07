using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 50f;
    public ZombieSpawner spawner; // Reference to the ZombieSpawner

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        // Notify the spawner that this zombie is killed
        if (spawner != null)
        {
            spawner.ZombieKilled();
        }

        Destroy(gameObject);
    }
}
