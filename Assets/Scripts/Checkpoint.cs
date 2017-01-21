using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

    public GameObject player;
    public Transform wave;
    Respawn respawn;

	// Use this for initialization
	void Start () {
        respawn = player.GetComponent<Respawn>();
	}
	
    void OnTriggerEnter (Collider collided)
    {
        if (collided.gameObject.tag == "Player")
        {
            respawn.checkpoint = transform;
            respawn.speed = player.GetComponent<PlayerController>().currentForwardSpeed;
            respawn.wavePos = wave.transform.position;
        }
    }
}
