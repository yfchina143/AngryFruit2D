using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    // power
    float power = 1.0f;
    // gravity
    float gravity = -5.0f;

    GameObject camera1;
    CameraController cameraController;
    Vector2 position;
    Vector2 prevPosition;

    // Use this for initialization
    void Start () {
        /*
        camera1 = GameObject.Find("Main Camera");
        cameraController = camera1.GetComponent<CameraController>();
        cameraController.SetCamera(transform);
        prevPosition = transform.position;
        */
	}
	
	// Update is called once per frame
	void Update () {

        /*
        position = transform.position;
        if ( Vector2.Distance(prevPosition, position) < 0.1f ) {
            cameraController.ResetCamera();
        }
        */

	}

    
    public void SetPower(float power1) {
        // Debug.Log("setPower called");
        power = power1;
    }
    
}
