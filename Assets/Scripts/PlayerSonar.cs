using UnityEngine;
using System.Collections;

public class PlayerSonar : MonoBehaviour {

    public Shader shader;
    public float sonarSpeed;
    public Color sonarColour;
    public float sonarThickness;
    public float sonarSpawnDistance;
    public float sonarDuration;
    public float sonarEmitDelay;
    public Transform submarineTransform;

    private float sonarDistance = 0;
    private float dissipation;

	void Start() {
        StartCoroutine(EmitSonarCoroutine());
	}
	
	void FixedUpdate() {
        sonarDistance += Time.fixedDeltaTime * sonarSpeed;
        dissipation -= Time.fixedDeltaTime * (1/sonarDuration);
        setShaderValues(getSonarPlaneEquation(), sonarColour, sonarThickness, dissipation);
	}

    private Vector4 getSonarPlaneEquation()
    {
        Vector3 normal = submarineTransform.forward;
        Vector3 point = submarineTransform.position + submarineTransform.forward * sonarDistance;

        float d = -normal.x * point.x - normal.y * point.y - normal.z * point.z;
        return new Vector4(normal.x, normal.y, normal.z, d);
    }

    private void setShaderValues(Vector4 plane, Vector4 colour, float thickness, float dissipation)
    {
        Shader.SetGlobalVector("_SonarEquation", plane);
        Shader.SetGlobalVector("_SonarColour", colour);
        Shader.SetGlobalFloat("_SonarThickness", thickness);
        Shader.SetGlobalFloat("_SonarDissipate", dissipation);
    }

    private IEnumerator EmitSonarCoroutine()
    {
        emitSonar(submarineTransform);
        yield return new WaitForSeconds(sonarDuration + sonarEmitDelay);
        StartCoroutine(EmitSonarCoroutine());
    }

    public void emitSonar(Transform submarineTransform)
    {
        this.submarineTransform = submarineTransform;
        this.dissipation = 1;
        sonarDistance = sonarSpawnDistance;
    }
}
