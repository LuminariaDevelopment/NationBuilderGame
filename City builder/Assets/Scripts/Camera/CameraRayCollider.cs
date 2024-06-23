using CameraControl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRayCollider : MonoBehaviour
{

    [SerializeField] LayerMask mask;
    CameraZoom _camZoom;

    private void Start()
    {
        _camZoom = FindAnyObjectByType<CameraZoom>();
    }

    void Update()
    {
        RaycastHit hit;

        if (Physics.Linecast(transform.position, transform.parent.parent.position, out hit, mask))
        {
            _camZoom.targetZoom += hit.distance;
        }
    }
}
