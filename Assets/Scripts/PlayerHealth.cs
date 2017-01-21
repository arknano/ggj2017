using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public float startingHealth;
    public float currentHealth;
    public Image healthSlider;
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
        healthSlider.fillAmount = currentHealth / 100;
    }

    public void TakeDamage(float damage)
    {
        currentHealth = currentHealth - damage;
    }
}
