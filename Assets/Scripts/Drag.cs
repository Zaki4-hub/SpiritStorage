using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    public float minDistance = 1f;
    public float maxDistance = 20f;
    public float zoomSpeed = 2f;

    private Camera mainCamera;
    private bool isDragging = false;
    private Vector3 offset;
    private float zCoord;


    void Start()
    {
        mainCamera = Camera.main;
    }

    void OnMouseDown()
    {
        zCoord = mainCamera.WorldToScreenPoint(transform.position).z;
        offset = transform.position - GetMouseWorldPos();
        isDragging = true;
    }

    void OnMouseUp()
    {
        isDragging = false;
    }

    void Update()
    {
        if (isDragging)
        {
            transform.position = GetMouseWorldPos() + offset;
            float scroll = Input.GetAxis("Mouse ScrollWheel");

            if (Mathf.Abs(scroll) > 0.01f)
            {
                zCoord += -scroll * zoomSpeed * 100f * Time.deltaTime;
                zCoord = Mathf.Clamp(zCoord, mainCamera.nearClipPlane + minDistance, mainCamera.farClipPlane - maxDistance);
            }
        }
    }

    Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = zCoord;
        return mainCamera.ScreenToWorldPoint(mousePoint);
    }
}
