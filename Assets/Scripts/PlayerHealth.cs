using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;

    public UIManager uiManager; // Reference to the UIManager for updating the UI

    // Property to expose current health
    public float CurrentHealth => currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log("Player Health: " + currentHealth);

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player Died!");

        // Update the UI to show "DIED" and activate the death message
        if (uiManager != null)
        {
            uiManager.ShowDeathMessage();
        }

        // Start the coroutine to delay the game pause
        StartCoroutine(DelayGamePause());
    }

    IEnumerator DelayGamePause()
    {
        yield return new WaitForSeconds(0.1f); // Wait for 0.1 seconds
        Time.timeScale = 0;  // Pause the game
    }
}
