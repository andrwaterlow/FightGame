using UnityEngine;

namespace Assets.Scripts
{
    public sealed class ManagerWindow : IManagerWindow
    {
        private IController _controller;
        private Restart _pause;

        public ManagerWindow(IController controller)
        {
            _controller = controller;
        }

        public void SetWindow(Restart Window)
        {
            _pause = Window;
        }

        public void Paused()
        { 
            if (_controller.AxisPause())
            {
                var pausedNow = _pause.gameObject.activeInHierarchy;

                if (!pausedNow)
                {
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                    _pause.gameObject.SetActive(true);
                    Time.timeScale = 0;
                }
                else
                {
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                    _pause.gameObject.SetActive(false);
                    Time.timeScale = 1;
                }
            }
        }
    }
}
