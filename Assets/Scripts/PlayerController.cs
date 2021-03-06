﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public float forwardSpeed;
    public float horizSpeed;
    public float vertSpeed;
    public float turnSpeed;
    public float slowSpeed;

    public float boostFactor;
    public float maxBoostSpeed;
    public float boostDrainSpeed;

    public float minPulsePower;
    public float pulseDrainSpeed;

    public Transform preWave;
    public float maxPrewaveDist;

    public float currentForwardSpeed;
    public float prewaveSpeedBoost;

    public PlayerSonar sonar;

    public int score;

    private float pulseTime = 0.0f;
    public float pulseInterval = 1.0f;

    Rigidbody rb;
    public Transform thruster;
    PlayerPower power;

    void Start () {
        rb = GetComponent<Rigidbody>();
        currentForwardSpeed = forwardSpeed;
        power = GetComponent<PlayerPower>();
    }
	
	void FixedUpdate () {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float turn = Input.GetAxis("Turn");

        float dist = Vector3.Distance(preWave.position, transform.position);
        prewaveSpeedBoost = (1 / dist) * maxPrewaveDist;
        if (prewaveSpeedBoost < 1)
        {
            prewaveSpeedBoost = 1;
        } else if (prewaveSpeedBoost >= 10){
            prewaveSpeedBoost = 10;
        }

        //when the boost button is held, increase the forward speed until it reaches the max speed
        if (Input.GetButton("Boost") && (power.currentPower >= 0))
        {
            currentForwardSpeed = currentForwardSpeed + Time.deltaTime * boostFactor;
            power.currentPower = power.currentPower - Time.deltaTime * boostDrainSpeed;
            if (currentForwardSpeed >= maxBoostSpeed)
            {
                currentForwardSpeed = maxBoostSpeed;
            }
        } else //when the button is not being pressed, reduce speed to the normal speed
        {
            currentForwardSpeed = currentForwardSpeed - Time.deltaTime * (boostFactor / 2);
            if (currentForwardSpeed <= forwardSpeed)
            {
                currentForwardSpeed = forwardSpeed;
            }
        }

        //when the pulse button is pressed, immediately take the initial power cost
        if (Input.GetButtonDown("Pulse"))
        {
            //power.currentPower = power.currentPower - minPulsePower;
            //sonar.emitSonar(transform);
        }

        ////while the pulse button is held, continue to draw power
        //if (Input.GetButton("Pulse") && (power.currentPower > 0))
        //{
        //    power.currentPower = power.currentPower - Time.deltaTime * pulseDrainSpeed;

        //}

        //if (Time.time >= pulseTime)
        //{
        //    sonar.emitSonar(transform);
        //    pulseTime = Time.time + pulseInterval;
        //}

        Vector3 velocity = rb.velocity;

        //move the player forward at a constant speed
        transform.Translate(transform.forward * currentForwardSpeed * prewaveSpeedBoost, Space.World);

        //add the lateral input speeds
        rb.AddForce(transform.right * horizontal * horizSpeed);
        rb.AddForce(transform.up * vertical * vertSpeed);

        //attempt to bring the player to a stop at all times (lateral speeds are higher than the stopping force)
        rb.AddForce(-velocity * slowSpeed);

        //turn the player on the y axis
        rb.AddForceAtPosition(-transform.right * turn * turnSpeed, thruster.position);

        //attempt to kill rotational velocity from turning (turning speed is higher than the stopping force)
        rb.angularVelocity = rb.angularVelocity * 0.9f;


    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(1);
    }
}
