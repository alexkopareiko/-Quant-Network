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
    private IInput[] m_Inputs;
    private InputData m_Input;

    private void Awake()
    {
        // gather inputs
        m_Inputs = GetComponents<IInput>();

    }

    private void Update()
    {
        GatherInputs();
    }

    private void FixedUpdate()
    {
        Move();
        ClampAngularVelocity(); 

    }

    void Move()
    {
        movement = (m_Input.Accelerate ? 1.0f : 0.0f) - (m_Input.Brake ? 1.0f : 0.0f);
        backTire.AddTorque(-movement * speed * Time.deltaTime);
        frontTire.AddTorque(-movement * speed * Time.deltaTime);
        carRigidbody.AddTorque(-movement * carTorque * Time.deltaTime);
    }

    // prevent chaotic movement of wheels
    // at high ang. speed
    void ClampAngularVelocity()
    {
        //back tire
        if (backTire.angularVelocity < -maxWheelTorque) { backTire.angularVelocity = -maxWheelTorque; }
        if (backTire.angularVelocity > maxWheelTorque) { backTire.angularVelocity = maxWheelTorque; }
       
        //front tire
        if (frontTire.angularVelocity < -maxWheelTorque) { frontTire.angularVelocity = -maxWheelTorque; }
        if (frontTire.angularVelocity > maxWheelTorque) { frontTire.angularVelocity = maxWheelTorque; }
    }

    void GatherInputs()
    {
        // reset input
        m_Input = new InputData();

        // gather nonzero input from our sources
        for (int i = 0; i < m_Inputs.Length; i++)
        {
            m_Input += m_Inputs[i].GenerateInput();
        }

    }
}
