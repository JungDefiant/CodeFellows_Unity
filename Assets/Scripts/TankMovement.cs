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

    public void MoveTank()
    {
        // Store a reference to our input
        var moveAxis = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        //var forward = transform.forward;    // (0, 0, 1) --> No value outside of 0, 1, or -1
        //rigidbody.AddForce(moveAxis * moveSpeed);
        rigidbody.velocity = moveAxis * moveSpeed;

        Debug.Log(moveAxis);

        //transform.position += (transform.forward * moveSpeed * Time.deltaTime);
    }
}
