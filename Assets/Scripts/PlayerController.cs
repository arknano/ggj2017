using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float forwardSpeed;
    public float horizSpeed;
    public float vertSpeed;
    public float turnSpeed;
    public float slowSpeed;
    public float boostFactor;
    public float maxBoostSpeed;
    public float boostDrainSpeed;

    float currentForwardSpeed;
    Rigidbody rb;
    public Transform thruster;
    PlayerPower power;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        currentForwardSpeed = forwardSpeed;
        power = GetComponent<PlayerPower>();
    }
	


	// Update is called once per frame
	void FixedUpdate () {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float turn = Input.GetAxis("Turn");

        Vector3 velocity = rb.velocity;

        if (Input.GetButton("Boost"))
        {
            currentForwardSpeed = currentForwardSpeed + Time.deltaTime * boostFactor;
            power.currentPower = power.currentPower - Time.deltaTime * boostDrainSpeed;
            if (currentForwardSpeed >= maxBoostSpeed)
            {
                currentForwardSpeed = maxBoostSpeed;
            }
        } else
        {
            currentForwardSpeed = currentForwardSpeed - Time.deltaTime * (boostFactor / 2);
            if (currentForwardSpeed <= forwardSpeed)
            {
                currentForwardSpeed = forwardSpeed;
            }
        }

        //rb.AddForce(transform.forward * 10)
        transform.Translate(transform.forward * currentForwardSpeed, Space.World);
        rb.AddForce(transform.right * horizontal * horizSpeed);
        rb.AddForce(transform.up * vertical * vertSpeed);
        rb.AddForce(-velocity * slowSpeed);

        rb.AddForceAtPosition(-transform.right * turn * turnSpeed, thruster.position);
        rb.angularVelocity = rb.angularVelocity * 0.9f;


    }
}
