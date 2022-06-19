using UnityEngine;
using UnityTools.Extentions;

namespace UnityTools.IO
{
    public class PCInputDevice : IInputDevice
    {
        public float cursorPosition { get; private set; }

        public bool isPressed => Input.GetMouseButton(0);

        public void UpdateInput()
        {
            UpdateInputDelta();
        }

        private void UpdateInputDelta()
        {
            if (Input.GetMouseButton(0))
                cursorPosition = (Input.mousePosition.x / Screen.width).Remap(0, 1, -1, 1);
        }
    }
}