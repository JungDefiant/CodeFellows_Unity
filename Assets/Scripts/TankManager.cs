using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class TankManager : MonoBehaviour
    {
        private TankMovement movement;
        private TankShooting shooting;
        private TankHealth health;
        private Camera mainCamera;

        void Start()
        {
            movement = GetComponent<TankMovement>();
            shooting = GetComponent<TankShooting>();
            health = GetComponent<TankHealth>();
            mainCamera = Camera.main;
        }

        void FixedUpdate()
        {
            // Store a reference to our input
            var moveAxis = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

            movement.MoveTank(moveAxis);

            // All of our turret rotation script here
            var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo; // Defining the raycast hit information

            // Projecting the actual raycast and outputting information on what we hit
            if (Physics.Raycast(ray, out hitInfo))
            {
                shooting.TankAim(hitInfo.point);
            }
            
            if (Input.GetMouseButton(0)) shooting.TankShoot();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.CompareTag("Projectile"))
            {
                var projectile = collision.gameObject.GetComponent<Projectile>();

                health.TakeDamage(projectile.GetDamage);

                Destroy(projectile.gameObject);
            }
        }
    }
}