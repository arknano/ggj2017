using UnityEngine;
using System.Collections;
using InControl;

public class PlayerController : MonoBehaviour {

    public float forwardSpeed;
    public float horizSpeed;
    public float vertSpeed;
    public float slowSpeed;

    InputDevice controller;
    Rigidbody rb;

    // Use this for initialization
    void Start () {
        controller = InputManager.ActiveDevice;
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        float horizontal = Input.GetAxis("Horizontal") + controller.LeftStick.X;
        float vertical = Input.GetAxis("Vertical") + controller.LeftStick.Y;
        float turn = Input.GetAxis("Turn") + controller.RightStick.X;

        Vector3 velocity = rb.velocity;

        //rb.AddForce(transform.forward * 10)
        transform.Translate(transform.forward * forwardSpeed, Space.World);
        rb.AddForce(transform.right * horizontal * horizSpeed);
        rb.AddForce(transform.up * vertical * vertSpeed);
        rb.AddForce(-velocity * slowSpeed);

        transform.Rotate(0, turn * 0.2f, 0);
    }
}
