using UnityEngine;
using System.Collections;

public class PlayerSonar : MonoBehaviour {

    public Shader shader;
    public float sonarSpeed;

    private const float INITIAL_SONAR_DISTANCE = 50;
    private float sonarDistance = INITIAL_SONAR_DISTANCE;

	void Start() {
	    
	}
	
	void FixedUpdate() {
        bool shootSonar = Input.GetButtonDown("Pulse");
        if (shootSonar)
        {
            Debug.Log("Fire");
            sonarDistance = INITIAL_SONAR_DISTANCE + transform.position.x;
        }
        sonarDistance += Time.fixedDeltaTime * sonarSpeed;

        Vector4 sonarPlane = getSonarPlane();
        Shader.SetGlobalVector("_SonarPlane", sonarPlane);
	}

    public Vector4 getSonarPlane()
    {
        return new Vector4(sonarDistance, 0, 0, 1);
    }
}
