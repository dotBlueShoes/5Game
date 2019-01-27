using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
[ExecuteInEditMode]
public class RadiusGenerator : MonoBehaviour {

    public int vectors = 10;
    public float radius = 1;

    private LineRenderer lr;

    void Awake(){
        lr = GetComponent<LineRenderer>();
        lr.positionCount = vectors;
    }

	void Start() {
        Vector3 position;
        float deltaTheta = (2f * Mathf.PI / vectors);
        float theta = 0f;

        for(int i = 0; i < vectors; i++) {
            position = new Vector3((radius) * Mathf.Cos(theta), (radius) * Mathf.Sin(theta), 0);
            if (transform.parent != null) position += transform.position;
            lr.SetPosition(i, position);
            theta += deltaTheta;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
