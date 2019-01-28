using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // Debug.Log("Position: " + transform.position);

        if (Input.GetKey(KeyCode.UpArrow)) {
            transform.RotateAround(transform.position, transform.forward, Time.deltaTime * 90f);
        }
        if (Input.GetKey(KeyCode.DownArrow)) {
            transform.RotateAround(transform.position, transform.forward, Time.deltaTime * -90f);
        }

        // Debug.Log("Angle: " + transform.eulerAngles);
    }
}
