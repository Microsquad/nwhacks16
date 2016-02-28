using UnityEngine;
using System.Collections;

public class ObjMain : MonoBehaviour {

	public string FolderPath = "";
	public string ObjectFile = "";
	public bool LoadLocalModel = false;

	// Use this for initialization
	void Start () {

		if(LoadLocalModel) return; //skip all loading

		Mesh holderMesh = new Mesh();
        ObjectImporter newMesh = new ObjectImporter();
        string systemPath = Application.streamingAssetsPath;
        if(systemPath[systemPath.Length - 1] != '/')
        {
        	systemPath += '/';
        }
        string fullPath = systemPath + FolderPath + ObjectFile; 
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
