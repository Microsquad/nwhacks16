using UnityEngine;
using System.Collections;

public class ObjMain : MonoBehaviour {

	public string FolderPath = "";
	public string ObjectFile = "";
	public bool LoadLocalModel = false;
	public Material CustomMaterial;

    public GameObject newObj;

	public string endpoint = "http://104.236.185.75:3000/getobj";

	private WWW www;
    private WWW www2;

	public IEnumerator getObj() {

        yield return www;

		Mesh holderMesh = new Mesh();
		ObjectImporter newMesh = new ObjectImporter();
        holderMesh = newMesh.ImportFile(www.text);

        foreach (Transform trans in this.gameObject.transform)
        {
            GameObject.Destroy(trans.gameObject);
        }

        GameObject child = Instantiate(newObj);
        child.transform.parent = this.gameObject.transform;
                
        MeshRenderer renderer = child.AddComponent<MeshRenderer>();
        MeshFilter filter = child.AddComponent<MeshFilter>();       
		child.GetComponent<Renderer>().sharedMaterial = CustomMaterial;
 
        filter.mesh = holderMesh;

        CenterObject(child);

        
        
    }

	// Use this for initialization
	void Start () {

		if(LoadLocalModel) return; //skip all loading

        www = new WWW(endpoint);
		StartCoroutine (getObj ());

	}

	private void CenterObject(GameObject child)
    {
        Vector3 x = child.GetComponent<MeshRenderer>().bounds.center;
        Debug.Log(x);
       child.transform.Translate(-x, Space.World);
    }

    public void btnClick()
    {
        www.Dispose();
        www = new WWW(endpoint);
        StartCoroutine(getObj());
    }

	
}
