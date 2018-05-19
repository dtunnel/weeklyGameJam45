using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    private GameObject target;

    public float smoothSpeed = 0.125f;
    public Vector3 offset; 

	// Use this for initialization
	void Start () {

        // Initializes target as player
        target = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        /*
        Vector3 desiredPosition = target.transform.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
	    */
        transform.position = target.transform.position + offset;
    }
}
