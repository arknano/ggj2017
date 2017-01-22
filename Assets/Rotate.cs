using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Rotate : MonoBehaviour {

    public float speed = 1;
    public int value = 1;
    PlayerController player;
    Text score;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
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
            score.text = "Score: " + player.score;
            Destroy(gameObject);
        }
    }
}
