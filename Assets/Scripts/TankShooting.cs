using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShooting : MonoBehaviour
{
    [SerializeField] private float attackSpeed;
    [SerializeField] private Transform turretGun;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bullet;
    private Camera mainCamera;
    private float attackTimer;

    private void Start()
    {
        mainCamera = Camera.main;
        attackTimer = 0;
    }

    public void TankAim()
    {
        // All of our turret rotation script here
        var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        var turretPosition = turretGun.position;

        RaycastHit hitInfo; // Defining the raycast hit information

        // Projecting the actual raycast and outputting information on what we hit
        if (Physics.Raycast(ray, out hitInfo))
        {
            var relativePosition = hitInfo.point - turretPosition;
            //var relativePosition = turretGun.InverseTransformPoint(mouseToWorldPos);

            var angle = Mathf.Atan2(relativePosition.x, relativePosition.z) * Mathf.Rad2Deg;
            turretGun.rotation = Quaternion.Euler(new Vector3(0, angle, 0));
        }
    }

    public void TankShoot()
    {
        attackTimer += Time.deltaTime;

        // If you left click and the timer is above the attack speed, then shoot
        if (attackTimer >= attackSpeed && Input.GetMouseButtonDown(0))
        {
            // Create the bullet
            Instantiate(bullet, firePoint.position, turretGun.rotation);
            // Reset the timer
            attackTimer = 0;
        }
    }
}
