using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float impactForce = 30f;
    public float fireRate = 15f;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;

    public int magazineSize = 30; // Number of bullets per magazine
    private int currentAmmo; // Current bullets in the magazine
    public float reloadTime = 2f; // Time to reload in seconds
    private bool isReloading = false;

    private float nextTimeToFire = 0f;

    public LayerMask whatIsPlayer; // Layer to specify what to ignore

    // Properties to expose ammo information for the UIManager
    public int CurrentAmmo => currentAmmo;
    public int MaxAmmo => magazineSize;

    void Start()
    {
        currentAmmo = magazineSize; // Start with a full magazine
    }

    void Update()
    {
        if (isReloading)
            return;

        if (currentAmmo <= 0 || Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Reloading...");
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        muzzleFlash.Play();
        currentAmmo--; // Use one bullet
        Debug.Log("Shots fired! Remaining ammo: " + currentAmmo);

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range, ~whatIsPlayer))
        {
            if (hit.transform.CompareTag("Player"))
            {
                Debug.Log("Ignored player hit.");
                return;
            }

            Debug.Log(hit.transform.name);

            Enemy target = hit.transform.GetComponent<Enemy>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

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
