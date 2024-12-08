using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("UI Elements")]
    public TextMeshProUGUI bulletsText;
    public TextMeshProUGUI roundText;
    public TextMeshProUGUI zombiesText;
    public TextMeshProUGUI healthText; // For player's health
    public TextMeshProUGUI deathText;  // For the "DIED" message


    [Header("Game References")]
    public ZombieSpawner zombieSpawner;
    public Weapon playerWeapon;
    public PlayerHealth playerHealth; // Reference to the player's health script


    void Start()
    {
        if (deathText != null)
        {
            deathText.gameObject.SetActive(false);  // Deactivate the DIED text object initially
        }
    }

    void Update()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        // Update bullets left
        if (playerWeapon != null)
        {
            bulletsText.text = $"Bullets: {playerWeapon.CurrentAmmo}/{playerWeapon.MaxAmmo}";
        }

        // Update current round
        if (zombieSpawner != null)
        {
            roundText.text = $"Round: {zombieSpawner.CurrentRound}";
        }

        // Update zombies left
        if (zombieSpawner != null)
        {
            zombiesText.text = $"Zombies Left: {zombieSpawner.ZombiesAlive + zombieSpawner.ZombiesRemainingInRound}";
        }

        // Update player's health
        if (playerHealth != null)
        {
            healthText.text = $"Health: {playerHealth.CurrentHealth}/{playerHealth.maxHealth}";
        }
    }

    public void ShowDeathMessage()
    {
        // Check if the deathText is assigned and is not null
        if (deathText != null)
        {
            // Activate the DIED text object and set the message
            deathText.gameObject.SetActive(true);  // Ensure it is visible
            deathText.text = "DIED";              // Set the "DIED" message
            
            // Optionally, you could add some effects, animation, or a delay before the message appears.
        }
        else
        {
            Debug.LogError("DeathText is not assigned in the UIManager!");
        }
    }
}
