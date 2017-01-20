using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerPower : MonoBehaviour {

    public int startingPower;
    public float currentPower;
    public Slider powerSlider;
    public float rechargeSpeed;

	// Use this for initialization
	void Start () {
        currentPower = startingPower;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        currentPower = currentPower + Time.deltaTime * rechargeSpeed;
        if (currentPower >= startingPower)
        {
            currentPower = startingPower;
        }
        powerSlider.value = currentPower;
	}
}
