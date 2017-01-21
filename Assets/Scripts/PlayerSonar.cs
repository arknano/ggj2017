using UnityEngine;
using System.Collections;

public class PlayerSonar : MonoBehaviour {

    public Shader shader;
    public float sonarSpeed;
    public Color sonarColour;
    public float sonarThickness;

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

        setShaderValues(getSonarPlane(), sonarColour, sonarThickness);
	}

    public Vector4 getSonarPlane()
    {
        return new Vector4(sonarDistance, 0, 0, 1);
    }

    private void setShaderValues(Vector4 plane, Vector4 colour, float thickness)
    {
        Shader.SetGlobalVector("_SonarPlane", plane);
        Shader.SetGlobalVector("_SonarColour", colour);
        Shader.SetGlobalFloat("_SonarThickness", thickness);
    }
}
