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

        setShaderValues(getSonarPlaneEquation(), sonarColour, sonarThickness);
	}

    private Vector4 getSonarPlaneEquation()
    {
        Vector3 normal = transform.forward;
        Vector3 point = transform.position + transform.forward * sonarDistance;

        float d = -normal.x * point.x - normal.y * point.y - normal.z * point.z;
        return new Vector4(normal.x, normal.y, normal.z, d);
    }

    private void setShaderValues(Vector4 plane, Vector4 colour, float thickness)
    {
        Shader.SetGlobalVector("_SonarEquation", plane);
        Shader.SetGlobalVector("_SonarColour", colour);
        Shader.SetGlobalFloat("_SonarThickness", thickness);
    }
}
