using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShooting : MonoBehaviour
{
    [SerializeField] private float attackSpeed;
    [SerializeField] private Transform turretGun;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bullet;
    private float attackTimer;

    public Transform GetTurret { get; }

    private void Start()
    {
        attackTimer = 0;
    }

    public void TankAim(Vector3 targetPosition)
    {
        var turretPosition = turretGun.position;

        // Target position is either raycast hit (for a player) or the player position (for an enemy)
        var relativePosition = targetPosition - turretPosition;

        var angle = Mathf.Atan2(relativePosition.x, relativePosition.z) * Mathf.Rad2Deg;
        turretGun.rotation = Quaternion.Euler(new Vector3(0, angle, 0));
    }

    public void TankShoot()
    {
        attackTimer += Time.deltaTime;

        // If you left click and the timer is above the attack speed, then shoot
        if (attackTimer >= attackSpeed)
        {
            // Create the bullet
            var newBullet = Instantiate(bullet, firePoint.position, turretGun.rotation);

            var ownerLayer = gameObject.layer;

            newBullet.layer = ownerLayer;

            // Reset the timer
            attackTimer = 0;
        }
    }
}
