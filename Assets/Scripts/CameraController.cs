using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public Transform target;
    public Color fogColour;
    public float fogDistance;

    public float distanceFromTarget;
    public float positionLerpMultiplier;
    public float rotationLerpMultiplier;
    private Vector3 offset;

	void Start () {
        //offset = transform.position - target.transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 fromPosition = transform.position;
        Vector3 toPosition = target.transform.position 
            - distanceFromTarget * target.transform.forward + transform.up * 2;
        
        //Vector3.Lerp(fromPosition, toPosition, Time.fixedDeltaTime * maxPositionLerpMultiplier);
        Vector3 deltaPosition = (toPosition - fromPosition) *
            Time.fixedDeltaTime * positionLerpMultiplier;
        Vector3 movementDirection = Vector3.Normalize(deltaPosition);
        transform.position = transform.position + deltaPosition;
        
        Quaternion fromRotation = transform.rotation;
        Quaternion toRotation = Quaternion.LookRotation(
            target.transform.position - transform.position,
            target.transform.up) * Quaternion.Euler(0, 180, 0);
        transform.rotation = Quaternion.Slerp(fromRotation, toRotation,
            Time.fixedDeltaTime * rotationLerpMultiplier);

        Shader.SetGlobalVector("_CameraPosition", transform.position);
        Shader.SetGlobalVector("_FogColour", fogColour);
        Shader.SetGlobalFloat("_FogDistance", fogDistance);
    }
}
