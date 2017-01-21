using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour {

    public Transform checkpoint;
    public float speed;
    public Vector3 wavePos;
    public Transform wave;
    PlayerController pc;

	// Use this for initialization
	void Start () {
	    pc = GetComponent<PlayerController>();
    }
	
	// Update is called once per frame
	public void RespawnPlayer () {
        print("hello");
        transform.position = checkpoint.position;
        transform.rotation = checkpoint.rotation;
        pc.currentForwardSpeed = speed;
        wave.position = wavePos;
    }
}
