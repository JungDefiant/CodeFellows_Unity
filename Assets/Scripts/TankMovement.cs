using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    private Rigidbody rigidbody;
    [SerializeField] private float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public void MoveTank(Vector3 moveAxis)
    {
        rigidbody.velocity = moveAxis * moveSpeed;
    }
}
