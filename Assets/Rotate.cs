using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

    public float speed = 1;
    public int value = 1;
    PlayerController player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.up * Time.deltaTime * speed);
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.score = player.score + value;
            Destroy(gameObject);
        }
    }
}
