using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PhysicsMovement : MonoBehaviour
{
    [SerializeField] private float jumpPower;
    [SerializeField] private float rotationPower;
    private Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (rb.velocity.magnitude <= 0.01f)
        {
            Jump();
        }
    }

    private void Jump()
    {
        rb.AddForce(new Vector3(0,1,1) * jumpPower, ForceMode.Impulse);
        rb.AddTorque(Vector3.right* rotationPower, ForceMode.Impulse);
    }
}
