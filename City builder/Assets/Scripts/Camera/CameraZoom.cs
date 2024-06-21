using UnityEngine;

namespace CameraControl {
    public class CameraZoom : MonoBehaviour {
        [SerializeField] private float zoomSpeed = 5f;
        [SerializeField] private float zoomSmoothing = 5f;
        [SerializeField] private Vector2 zoomRange = new Vector2(5f, 20f);
        [SerializeField] private Transform cameraTransform;

        public float targetZoom;
        private float currentZoom;

        private void Awake() {
            currentZoom = targetZoom = -zoomRange.y;
        }

        private void Update() {
            HandleInput();
            Zoom();
        }

        private void HandleInput() {
            float zoomInput = Input.GetAxis("Mouse ScrollWheel");
            targetZoom = Mathf.Clamp(targetZoom + zoomInput * zoomSpeed, -zoomRange.y, -zoomRange.x);
        }

        private void Zoom() {
            currentZoom = Mathf.Lerp(currentZoom, targetZoom, Time.deltaTime * zoomSmoothing);
            Vector3 newPosition = cameraTransform.localPosition;
            newPosition.z = currentZoom;
            cameraTransform.localPosition = newPosition;
        }
    }
}
