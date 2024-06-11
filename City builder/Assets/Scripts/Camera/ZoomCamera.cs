using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomCamera : MonoBehaviour
{
    float yLevel;
    public float zoomingSpeed;
    public float step;
    public float camMaxY;
    GameObject origin;

    private void Start()
    {
        origin = GameObject.Find("CameraAnchor");
    }

    void Update()
    {
        yLevel -= Input.mouseScrollDelta.y;
        yLevel = Mathf.Clamp(yLevel, 2, camMaxY);
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, yLevel, transform.position.z), step);
        transform.LookAt(origin.transform.position);
    }
}
