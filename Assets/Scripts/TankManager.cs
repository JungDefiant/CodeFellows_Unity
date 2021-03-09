using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class TankManager : MonoBehaviour
    {

        private TankMovement movement;
        private TankShooting shooting;

        void Start()
        {
            movement = GetComponent<TankMovement>();
            shooting = GetComponent<TankShooting>();
        }

        void FixedUpdate()
        {
            movement.MoveTank();
            shooting.TankAim();
            shooting.TankShoot();
        }
    }
}