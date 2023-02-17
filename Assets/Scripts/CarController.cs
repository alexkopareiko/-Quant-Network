using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D backTire;
    [SerializeField] private Rigidbody2D frontTire;
    [SerializeField] private Rigidbody2D carRigidbody;
    [SerializeField] private float speed = 100f;
    [SerializeField] private float carTorque = 10f;
    [SerializeField] private float maxWheelTorque = 1000f;
    private float movement;


    private void Update()
    {
        movement = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        backTire.AddTorque(-movement * speed * Time.deltaTime, ForceMode2D.Force);
        frontTire.AddTorque(-movement * speed * Time.deltaTime, ForceMode2D.Force);
        carRigidbody.AddTorque(-movement * carTorque * Time.deltaTime, ForceMode2D.Force);
        ClampAngularVelocity();
    }

    void ClampAngularVelocity()
    {
        if (backTire.angularVelocity < -maxWheelTorque) { backTire.angularVelocity = -maxWheelTorque; }
        if (backTire.angularVelocity > maxWheelTorque) { backTire.angularVelocity = maxWheelTorque; }
        
        if (frontTire.angularVelocity < -maxWheelTorque) { frontTire.angularVelocity = -maxWheelTorque; }
        if (frontTire.angularVelocity > maxWheelTorque) { frontTire.angularVelocity = maxWheelTorque; }
    }
}
