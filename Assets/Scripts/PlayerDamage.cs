using UnityEngine;
using System.Collections;

public class PlayerDamage : MonoBehaviour {

    PlayerHealth health;
    PlayerController player;
    float damage;

    public float damageMultiplier;
    private float damageTime = 0.0f;
    public float damageInterval = 1.0f;

    private bool damageEnabled = true;

    // Use this for initialization
    void Start () {
        health = GetComponent<PlayerHealth>();
        player = GetComponent<PlayerController>();
    }
	
	// Update is called once per frame
	void Update () {
        //damage = player.currentForwardSpeed * player.prewaveSpeedBoost * 100;
        
	}

    void OnCollisionEnter (Collision collision)
    {
        slideCollision(collision);
        StartCoroutine(DisableDamage());
    }

    private void slideCollision(Collision collision)
    {
        float dotProduct = Vector3.Dot(-collision.contacts[0].normal, transform.forward);
        float angle = 90 - (180 / Mathf.PI) * Mathf.Acos(dotProduct);
        float pain = damageMultiplier * (angle / 90) * player.currentForwardSpeed;
        if (damageEnabled)
        {
            damage -= pain;
            health.TakeDamage(pain);
        }

        Debug.DrawRay(transform.position, transform.up * 20 * pain, Color.magenta);
        /*if (Time.time >= damageTime)
        {
            health.TakeDamage(damage);
            damageTime = Time.time + damageInterval;
        }*/
    }

    private IEnumerator DisableDamage()
    {
        damageEnabled = false;
        yield return new WaitForSeconds(damageTime);
        damageEnabled = true;
    }
}
