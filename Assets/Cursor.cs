using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour {

    CameraRaycaster cameraraycaster;
    // Use this for initialization
    void Start () {
        cameraraycaster = GetComponent<CameraRaycaster>();
    }
	
	// Update is called once per frame
	void Update () {
        // Debug.Log(cameraraycaster.layerHit);
	}
}
