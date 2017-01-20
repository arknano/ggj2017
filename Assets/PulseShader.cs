using UnityEngine;
using System.Collections;

public class PulseShader : MonoBehaviour {

    public Renderer rend;

    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
        rend.material.shader = Shader.Find("SonarShader");
    }
	
	// Update is called once per frame
	void Update () {
        rend.material.SetFloat("_TestPosWow.x", 100);
	}
}
