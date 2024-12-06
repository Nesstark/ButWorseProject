using UnityEngine;

public class MoveWeapon : MonoBehaviour
{
    public Transform weaponPosition;

    private void Update() {
        transform.position = weaponPosition.position;
    }
}
