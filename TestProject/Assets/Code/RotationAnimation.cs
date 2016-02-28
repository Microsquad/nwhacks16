using UnityEngine;
using System.Collections;

public class RotationAnimation : MonoBehaviour {

    public float speed = 10f;
    
    void Start()
    {
        
    }

    public void CenterObject()
    {
        Vector3 x = this.gameObject.GetComponent<MeshRenderer>().bounds.center;
        this.gameObject.transform.Translate(-x);
    }

	// Update is called once per frame
	void Update () {
        
        this.gameObject.transform.Rotate(Vector3.up * speed * Time.deltaTime, Space.World);
	}
}
