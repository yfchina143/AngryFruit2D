using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    Transform platformTransform;
    Transform targetTransform;

    float cameraSize = 20;
    Vector3 cameraPosition = new Vector3(25, 5, -10);

	// Use this for initialization
	void Start () {
        platformTransform = GameObject.Find("Platform").GetComponent<PlayerController>().transform;
        targetTransform = transform;
        transform.position = cameraPosition + platformTransform.position;
        GetComponent<Camera>().orthographicSize = cameraSize;
        
        // transform.position = platformTransform.position + new Vector3(0,0,-10.0f);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = targetTransform.position;
	}

    public void SetCamera(Transform bulletTransform) {
        // targetTransform = bulletTransform;
    }

    public void ResetCamera() {
        // targetTransform = platformTransform;
    }
}
