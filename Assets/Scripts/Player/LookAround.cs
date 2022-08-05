using UnityEngine;

namespace Assets.Scripts
{
    public sealed class LookAround : ILookAround
    {
        private float minVert = -45f;
        private float maxVert = 45f;
        private float rotationX = .0f;
        private float rotationY = .0f;

        private float _sensitivity;

        private Camera _camera;
        private Rigidbody _rigidBody;
        private Player _player;

        public LookAround(Camera camera, Rigidbody rigidBody, float sensitivity, Player player)
        {
            _camera = camera;
            _rigidBody = rigidBody;
            _sensitivity = sensitivity;
            _player = player;
            Start();
        }

        private void Start()
        {
            if (_rigidBody != null)
            {
                _rigidBody.freezeRotation = true;
            }
        }

        public void Rotation()
        {
            rotationX -= Input.GetAxis("Mouse Y") * _sensitivity;
            rotationY += Input.GetAxis("Mouse X") * _sensitivity;
            rotationX = Mathf.Clamp(rotationX, minVert, maxVert);
            _player.transform.rotation = Quaternion.Euler(0, rotationY, 0);
            _camera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        }
    }
}
