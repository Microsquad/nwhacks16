using UnityEngine;
using System.Collections;

public class ObjMain : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Mesh holderMesh = new Mesh();
        ObjectImporter newMesh = new ObjectImporter();
        holderMesh = newMesh.ImportFile("D:/Personal_Data/Projects/Unity/3dtest/nwhacks16/TestProject/Assets/3dmodel/teapot.obj");

        MeshRenderer renderer = gameObject.AddComponent<MeshRenderer>();
        MeshFilter filter = gameObject.AddComponent<MeshFilter>();
        filter.mesh = holderMesh;
	}
	
}
