using UnityEngine;
using System.Collections;

public class RotationAnimation : MonoBehaviour {

    public float speed = 10f;
    public float ManualSpeed = 10f;
    private bool isManualRotating;
    private Vector3 startPosition;
    
    void Start()
    {
        isManualRotating = false;
        startPosition = Vector3.zero;
    }

	// Update is called once per frame
	void Update () 
    {
        if(Input.GetMouseButtonDown(0))
        {
            startPosition = Input.mousePosition;
        }

        isManualRotating = Input.GetMouseButton(0);
        
        if(isManualRotating)
        {
            Vector3 delta = Input.mousePosition - startPosition;
            if(Mathf.Abs(delta.x) - Mathf.Abs(delta.y) > 0f)
            {
                this.gameObject.transform.Rotate(Vector3.right * ManualSpeed * delta.x, Space.World);
            }
            else
            {
                this.gameObject.transform.Rotate(Vector3.up * ManualSpeed * delta.y, Space.World);
            }
           
            startPosition = Input.mousePosition;
        }
        else
        {
            this.gameObject.transform.Rotate(Vector3.up * speed * Time.deltaTime, Space.World);
    	}
    }




}
