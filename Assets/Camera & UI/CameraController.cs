using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform target;

    public Vector3 offset;
    public float zoomSpeed = 4f;
    public float minZoom = 5f;
    public float maxZoom = 15f;
    public float pitch = 2f;

    public float yawSpeed = 100f;

    private float currentZoom = 10f;
    private float currentYaw = 0f;
	
	void Update () {

        if (PlayerMovement.isInDirectMode)
        {
            // Handle Direct Movement

            // Zoom camera with A/B Joystick Buttons
            currentZoom -= Input.GetAxis("Fire1") * zoomSpeed * Time.deltaTime; 
            currentZoom += Input.GetAxis("Fire2") * zoomSpeed * Time.deltaTime; 
            currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

            // Rotate camera using Left/Right Joystick Bumpers
            currentYaw -= Input.GetAxis("Fire4") * yawSpeed * Time.deltaTime;
            currentYaw += Input.GetAxis("Fire5") * yawSpeed * Time.deltaTime;
        }
        else
        {
            // Handle Mouse Movement

            currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
            currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

            if (Input.GetMouseButton(2))
            {
                currentYaw -= Input.GetAxis("Mouse X") * yawSpeed * Time.deltaTime;
            }
            
        }

    }
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = target.position - offset * currentZoom;
        transform.LookAt(target.position + Vector3.up * pitch);

        transform.RotateAround(target.position, Vector3.up, currentYaw);
	}
}
