using UnityEngine;
using System.Collections;

public class ObjMain : MonoBehaviour {

	public string Path = "";

	// Use this for initialization
	void Start () {
		Mesh holderMesh = new Mesh();
        ObjectImporter newMesh = new ObjectImporter();
        holderMesh = newMesh.ImportFile(Path);

        MeshRenderer renderer = this.gameObject.AddComponent<MeshRenderer>();
        MeshFilter filter = this.gameObject.AddComponent<MeshFilter>();

        GameObject primitive = GameObject.CreatePrimitive(PrimitiveType.Plane);
		primitive.active = false;
		Material diffuse = primitive.GetComponent<MeshRenderer>().sharedMaterial;
		DestroyImmediate(primitive);
		// ...
		this.gameObject.GetComponent<Renderer>().sharedMaterial = diffuse;

        filter.mesh = holderMesh;

        this.gameObject.GetComponent<RotationAnimation>().CenterObject();
	}
	
}
