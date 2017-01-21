using UnityEngine;
using System.Collections;

public class PlayerSonar : MonoBehaviour {

    public Shader shader;
    public float sonarSpeed;
    public Color sonarColour;
    public float sonarThickness;
    public float sonarSpawnDistance;

    private Transform submarineTransform = null;
    private float sonarDistance = 0;

	void Start() {
	    
	}
	
	void FixedUpdate() {
        if (submarineTransform != null)
        {
            sonarDistance += Time.fixedDeltaTime * sonarSpeed;
            setShaderValues(getSonarPlaneEquation(), sonarColour, sonarThickness);
        }
	}

    private Vector4 getSonarPlaneEquation()
    {
        Vector3 normal = submarineTransform.forward;
        Vector3 point = submarineTransform.position + submarineTransform.forward * sonarDistance;

        float d = -normal.x * point.x - normal.y * point.y - normal.z * point.z;
        return new Vector4(normal.x, normal.y, normal.z, d);
    }

    private void setShaderValues(Vector4 plane, Vector4 colour, float thickness)
    {
        Shader.SetGlobalVector("_SonarEquation", plane);
        Shader.SetGlobalVector("_SonarColour", colour);
        Shader.SetGlobalFloat("_SonarThickness", thickness);
    }

    public void emitSonar(Transform submarineTransform)
    {
        this.submarineTransform = submarineTransform;
        sonarDistance = sonarSpawnDistance;
    }
}
