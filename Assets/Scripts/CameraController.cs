using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float distance = 10f;
    public float height = 5f;
    public float rotationDamping = 1f;
    public float heightDamping = 1f;
    public float zoomSpeed = 2f;
    public float maxZoom = 5f;
    public float minZoom = 20f;

    private float currentRotationAngle = 0f;
    private float currentHeight = 0f;

    void LateUpdate()
    {
        if (!target) return;

        
        float desiredRotationAngle = target.eulerAngles.y*-1;
        float desiredHeight = target.position.y + height;

        currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, desiredRotationAngle, rotationDamping * Time.deltaTime);
        currentHeight = Mathf.Lerp(currentHeight, desiredHeight, heightDamping * Time.deltaTime);

        Quaternion currentRotation = Quaternion.Euler(0f, currentRotationAngle, 0f);

       
        Vector3 targetPosition = target.position - currentRotation * Vector3.forward * distance;
        targetPosition.y = currentHeight;

        // kameranın yakınlaşma ve uzaklaşma mesafesi
        float scroll = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        distance = Mathf.Clamp(distance - scroll, maxZoom, minZoom);

        transform.position = targetPosition;
        transform.LookAt(target);
    }
}
