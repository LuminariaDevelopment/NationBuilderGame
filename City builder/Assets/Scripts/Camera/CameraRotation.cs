using UnityEngine;

namespace CameraControl {
	public class CameraRotation : MonoBehaviour {
		[SerializeField] private float _speed = 15f;
		[SerializeField] private float _smoothing = 5f;
		
		private float _targetAngle;
		public float _targetAngleX;
		private float _currentAngle;
        private float _currentAngleX;

		private Vector3 _targetAngleXYZ;

        private void Awake() {
			_targetAngle = transform.eulerAngles.y;
			_targetAngleX = transform.eulerAngles.x;
			_currentAngle = _targetAngle;
            _currentAngle = _targetAngle;
        }

        private void HandleInput() {
			if (!Input.GetMouseButton(2)) return;
			_targetAngle += Input.GetAxisRaw("Mouse X") * _speed;
            _targetAngleX -= Input.GetAxisRaw("Mouse Y") * _speed;
			_targetAngleX = Mathf.Clamp(_targetAngleX, -20, 20);
        }

        private void Rotate() {
			_currentAngle = Mathf.Lerp(_currentAngle, _targetAngle, Time.deltaTime * _smoothing);
            _currentAngleX = Mathf.Lerp(_currentAngleX, _targetAngleX, Time.deltaTime * _smoothing);

			_targetAngleXYZ = new Vector3(_targetAngleX, _targetAngle, 0);

			transform.rotation = Quaternion.Euler(_targetAngleXYZ);
        }

        private void Update() {
			HandleInput();
			Rotate();
		}
	}
}