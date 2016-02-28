using UnityEngine;
using System.Collections;

public class ObjMain : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Mesh holderMesh = new Mesh();
        ObjectImporter newMesh = new ObjectImporter();
        holderMesh = newMesh.ImportFile("D:/Personal_Data/Projects/Unity/3dtest/nwhacks16/TestProject/Assets/3dmodel/BeautifulGirl.obj");

        MeshRenderer renderer = this.gameObject.AddComponent<MeshRenderer>();
        MeshFilter filter = this.gameObject.AddComponent<MeshFilter>();

        GameObject primitive = GameObject.CreatePrimitive(PrimitiveType.Plane);
		primitive.active = false;
		Material diffuse = primitive.GetComponent<MeshRenderer>().sharedMaterial;
		DestroyImmediate(primitive);
		// ...
		this.gameObject.GetComponent<Renderer>().sharedMaterial = diffuse;

        filter.mesh = holderMesh;
	}
	
}
