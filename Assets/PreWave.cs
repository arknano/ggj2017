using UnityEngine;
using System.Collections;

public class PreWave : MonoBehaviour {

    public Transform player;
    public float speed;
    PlayerController pc;

	// Use this for initialization
	void Start () {
        pc = player.gameObject.GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime * pc.prewaveSpeedBoost);
	}
}
