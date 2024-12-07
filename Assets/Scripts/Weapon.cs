using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float impactForce = 30f;
    public float fireRate = 15f;

    public Camera fpsCam;

    public int magazineSize = 30; // Number of bullets per magazine
    private int currentAmmo; // Current bullets in the magazine
    public float reloadTime = 2f; // Time to reload in seconds
    private bool isReloading = false;

    private float nextTimeToFire = 0f;

    public LayerMask whatIsPlayer; // Layer to specify what to ignore

    void Start()
    {
        currentAmmo = magazineSize; // Start with a full magazine
    }

    void Update()
    {
        // If reloading, skip shooting
        if (isReloading)
            return;

        // Reload when out of ammo and Fire button is pressed
        if (currentAmmo <= 0)
        {
            Debug.Log("Out of ammo! Reloading...");
            StartCoroutine(Reload());
            return;
        }

        // Shooting logic
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        currentAmmo--; // Use one bullet
        Debug.Log("Shots fired! Remaining ammo: " + currentAmmo);

        RaycastHit hit;
        // Perform the raycast and ignore the "whatIsPlayer" layer (using the layer mask)
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range, ~whatIsPlayer))
        {
            // Ignore objects tagged "Player"
            if (hit.transform.CompareTag("Player"))
            {
                Debug.Log("Ignored player hit.");
                return;
            }

            Debug.Log(hit.transform.name);

            // Check if the hit object has an Enemy component
            Enemy target = hit.transform.GetComponent<Enemy>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            // Apply impact force to the hit object's rigidbody
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
        }
    }

    System.Collections.IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading...");

        yield return new WaitForSeconds(reloadTime);

        currentAmmo = magazineSize;
        Debug.Log("Reload complete! Ammo refilled to: " + currentAmmo);
        isReloading = false;
    }
}
