using UnityEngine;
using System.Collections;

public class CameraControls : MonoBehaviour {

	public Camera front, back, left, right;

	public float InitialDistance = 2f;

	// Use this for initialization
	void Start () {
		setCamerasDistances(InitialDistance);		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void setCamerasDistances(float distance)
	{
		var pos = front.gameObject.transform.position;
		pos.z = -distance;
		front.gameObject.transform.position = pos;

		pos = back.gameObject.transform.position;
		pos.z = distance;
		back.gameObject.transform.position = pos;

		pos = left.gameObject.transform.position;
		pos.x = -distance;
		left.gameObject.transform.position = pos;

		pos = right.gameObject.transform.position;
		pos.x = distance;
		right.gameObject.transform.position = pos;
	}
}
