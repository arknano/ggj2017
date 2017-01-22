using UnityEngine;
using System.Collections;

public class Endgame : MonoBehaviour {

    public GameObject winScreen;

	// Use this for initialization
	void Start () {
	
	}

    void OnTriggerEnter(Collider collided)
    {
        if (collided.gameObject.tag == "Player")
        {
            winScreen.SetActive(true);
        }
    }
}
