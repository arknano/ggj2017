﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public int startingHealth;
    public float currentHealth;
    public Slider healthSlider;
    public float rechargeSpeed;

    // Use this for initialization
    void Start()
    {
        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentHealth = currentHealth + Time.deltaTime * rechargeSpeed;
        if (currentHealth >= startingHealth)
        {
            currentHealth = startingHealth;
        }
        healthSlider.value = currentHealth;
    }
}