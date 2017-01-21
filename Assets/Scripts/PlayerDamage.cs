using UnityEngine;
using System.Collections;

public class PlayerDamage : MonoBehaviour {

    PlayerHealth health;
    PlayerController player;
    float damage;

    private float damageTime = 0.0f;
    public float damageInterval = 1.0f;

    // Use this for initialization
    void Start () {
        health = GetComponent<PlayerHealth>();
        player = GetComponent<PlayerController>();
    }
	
	// Update is called once per frame
	void Update () {
        damage = player.currentForwardSpeed * player.prewaveSpeedBoost * 100;
        
	}

    void OnCollisionEnter (Collision collided)
    {
        if (Time.time >= damageTime)
        {
            health.TakeDamage(damage);
            damageTime = Time.time + damageInterval;
        }
    }
}
