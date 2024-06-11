using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCameraMovement : MonoBehaviour
{
    Rigidbody camRb;
    Vector3 input;
    public float moveSpeed;

    private void Start()
    {
        camRb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.z = Input.GetAxisRaw("Vertical");
        input.Normalize();
        camRb.velocity = (transform.forward * input.z + transform.right * input.x) * Time.deltaTime * moveSpeed;
    }
}
