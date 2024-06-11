using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    float horizontalRotation;
    public float sensetivityVisual;
    public static float sensitivity;

    private void Start()
    {
        sensitivity = sensetivityVisual;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse2))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            horizontalRotation += Input.GetAxis("Mouse X") * sensitivity;
            transform.localEulerAngles = new Vector3(0, horizontalRotation, 0);
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
