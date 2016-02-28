using UnityEngine;
using System.Collections;

public class ObjMain : MonoBehaviour {

	public string FolderPath = "";
	public string ObjectFile = "";

	// Use this for initialization
	void Start () {
		Mesh holderMesh = new Mesh();
        ObjectImporter newMesh = new ObjectImporter();
        holderMesh = newMesh.ImportFile(FolderPath+ObjectFile);

        MeshRenderer renderer = this.gameObject.AddComponent<MeshRenderer>();
        MeshFilter filter = this.gameObject.AddComponent<MeshFilter>();

        GameObject primitive = GameObject.CreatePrimitive(PrimitiveType.Plane);
		primitive.active = false;
		Material diffuse = primitive.GetComponent<MeshRenderer>().sharedMaterial;
		DestroyImmediate(primitive);
		// ...
		this.gameObject.GetComponent<Renderer>().sharedMaterial = diffuse;

        filter.mesh = holderMesh;

        CenterObject();
	}

	private void CenterObject()
    {
        Vector3 x = this.gameObject.GetComponent<MeshRenderer>().bounds.center;
        this.gameObject.transform.Translate(-x);
    }
	
}
