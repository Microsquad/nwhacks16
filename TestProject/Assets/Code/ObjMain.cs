using UnityEngine;
using System.Collections;

public class ObjMain : MonoBehaviour {

	public string FolderPath = "";
	public string ObjectFile = "";
	public bool LoadLocalModel = false;

	public string endpoint = "http://104.236.185.75:3000/getobj";

	private WWW www;

	public IEnumerator getObj() {
		yield return www;

		Mesh holderMesh = new Mesh();
		ObjectImporter newMesh = new ObjectImporter();

		holderMesh = newMesh.ImportFile(www.text);

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

	// Use this for initialization
	void Start () {

		if(LoadLocalModel) return; //skip all loading

        www = new WWW(endpoint);
		StartCoroutine (getObj ());

	}

	private void CenterObject()
    {
        Vector3 x = this.gameObject.GetComponent<MeshRenderer>().bounds.center;
        Debug.Log(x);
        this.gameObject.transform.Translate(-x, Space.World);
    }


	
}
