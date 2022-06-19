using UnityEngine;
using UnityTools.Extentions;

namespace UnityTools.IO
{
    public class PhoneInputDevice : IInputDevice
    {
        public float cursorPosition { get; private set; }

        public bool isPressed => Input.GetMouseButton(0);

        public void UpdateInput()
        {
            UpdateLeftRightDelta();
        }

        private void UpdateLeftRightDelta()
        {
            if (Input.touchCount == 1)
            {
                var touch = Input.GetTouch(0);
                cursorPosition = (touch.position.x / Screen.width).Remap(0, 1, -1, 1);
            }
        }
    }
}