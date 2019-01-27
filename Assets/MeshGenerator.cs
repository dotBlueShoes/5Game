using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Not Used

[RequireComponent(typeof(MeshFilter))]
public class MeshGenerator : MonoBehaviour {

    private Mesh mesh;
    private Vector3[] vertices;
    private int[] triangles;

	private void Start () {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        CreateShape();
        MeshUpdate();
	}

    void CreateShape() {
        vertices = new Vector3[] {
            new Vector2(0, 0),
            new Vector2(0, 1),
            new Vector2(1, 0),
            new Vector2(1, 1)
        };
        triangles = new int[] {
            0, 1, 2,
            1, 3, 2
        };
    }

    void MeshUpdate() {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;
    }

}
