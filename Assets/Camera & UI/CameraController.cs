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

            // TODO - Player occasionally gets stuck facing the camera in this mode, work out why and fix.

            currentZoom -= Input.GetAxis("Vertical R"); // "Vertical R" being the right stick on the 360 controller
            currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
            currentYaw -= Input.GetAxis("Horizontal R") * yawSpeed * Time.deltaTime;
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
