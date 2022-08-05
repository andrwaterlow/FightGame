using UnityEngine;

namespace Assets.Scripts
{
    public sealed class Movement : IMovement
    {
        private IController _controller;
        private ILookAround _lookAround;

        public float _movingSpeed { get; private set; }
        private float _currentSpeed;
        private float GRAVITY = -9.8f;
        private float _heightJump = 400f;
        private bool _jamping;

        private Player _player;
        private Animate _animate;
        private CharacterController _characterController;
        
        public Movement(IController controller, float movingSpeed, Player player, 
            CharacterController characterController, ILookAround lookAround, Animate animate)
        {
            _controller = controller;
            _movingSpeed = movingSpeed;
            _currentSpeed = movingSpeed;
            _player = player;
            _characterController = characterController;
            _lookAround = lookAround;
            _animate = animate;
        }

        public void SetNewSpeed(float speed)
        {
            _movingSpeed = speed;
        }

        public void Move()
        {
            Vector3 movement;
            float speedZ = 0;
            float speedX = 0;

            /*AnimationRun(speedZ, speedX);
            AnimationWalk(speedZ, speedX);
            AnimationIdle(speedZ, speedX);*/

             movement = new Vector3(_controller.MoveAxisX() * _currentSpeed, 0,
            _controller.MoveAxisZ() * _currentSpeed);


            Jumping();
            movement.y = GRAVITY;
            movement = Vector3.ClampMagnitude(movement, _movingSpeed);
            
            movement *= Time.deltaTime;
            movement = _player.transform.TransformDirection(movement);
            _characterController.Move(movement);
        }

        private void AnimationRun(float speedZ, float speedX)
        {
            if (!_controller.AxisWalk())
            {
                if (_controller.MoveAxisZ() != 0)
                {
                    speedZ = _movingSpeed;
                    _currentSpeed = speedZ;
                    _animate.SetMovementAnimation(_controller.MoveAxisZ() * speedZ, speedX);

                    if (_controller.MoveAxisX() != 0)
                    {
                        speedX = _movingSpeed;
                        _animate.SetMovementAnimation(_controller.MoveAxisX() * speedZ, speedX);
                    }
                }

                if (_controller.MoveAxisX() != 0)
                {
                    speedX = _movingSpeed;
                    _currentSpeed = speedX;
                    _animate.SetMovementAnimation(_controller.MoveAxisX() * speedZ, speedX);

                    if (_controller.MoveAxisZ() != 0)
                    {
                        speedZ = _movingSpeed;
                        _animate.SetMovementAnimation(_controller.MoveAxisZ() * speedZ, speedX);
                    }
                }
            }
        }

        private void AnimationWalk(float speedZ, float speedX)
        {
            if(_controller.AxisWalk())
            {
                if (_controller.MoveAxisZ() != 0)
                {
                    speedZ = _movingSpeed / 3; ;
                    _currentSpeed = speedZ;
                    _animate.SetMovementAnimation(_controller.MoveAxisZ() * speedZ, speedX);

                    if (_controller.MoveAxisX() != 0)
                    {
                        speedX = _movingSpeed / 3; ;
                        _animate.SetMovementAnimation(_controller.MoveAxisX() * speedZ, speedX);
                    }
                }

                if (_controller.MoveAxisX() != 0)
                {
                    speedX = _movingSpeed / 3; ;
                    _currentSpeed = speedX;
                    _animate.SetMovementAnimation(_controller.MoveAxisX() * speedZ, speedX);

                    if (_controller.MoveAxisZ() != 0)
                    {
                        speedZ = _movingSpeed / 3; ;
                        _animate.SetMovementAnimation(_controller.MoveAxisZ() * speedZ, speedX);
                    }
                }
            }
        }

        private void AnimationIdle(float speedZ, float speedX)
        {
            if (_controller.MoveAxisX() == 0 && _controller.MoveAxisZ() == 0)
            {
                speedZ = 0;
                speedX = 0;
                _currentSpeed = speedZ;
                _animate.SetMovementAnimation(_controller.MoveAxisX(), _controller.MoveAxisZ());
            }
        }

        public void LookAround()
        {
            _lookAround.Rotation();
        }

        public void Jump()
        {
            if (_controller.AxisJump() && _characterController.isGrounded)
            {
                _jamping = true;
            }
        }

        private void Jumping()
        {
            if (_jamping)
            {
                float powerOfJump = 10000f;
                float initialValue = 400f;
                float StepOfSubtraction = 15f;

                _heightJump -= StepOfSubtraction;

                if (_heightJump >= 0)
                {
                    GRAVITY = powerOfJump;
                }

                else
                {
                    GRAVITY = -9.8f;
                    _heightJump = initialValue;
                    _jamping = false;
                }
            }
        }

        public bool Act()
        {
            return _controller.AxisAct();
        }
    }
}
