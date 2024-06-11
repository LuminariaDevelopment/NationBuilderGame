using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    Vector3 xz;
    Vector3 smoothedMovement;
    Vector3 inputVelocity;
    public Vector3 camStartPos;

    private void Start()
    {
        transform.position = camStartPos;
    }

    private void Update()
    {
        xz.x = Input.GetAxisRaw("Horizontal");
        xz.z = Input.GetAxisRaw("Vertical");
        xz.Normalize();
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, transform.position + xz, ref inputVelocity, 0.25f);
    }
}
