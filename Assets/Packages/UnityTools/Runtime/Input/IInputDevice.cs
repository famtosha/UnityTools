namespace UnityTools.IO
{
    public interface IInputDevice
    {
        float cursorPosition { get; }
        bool isPressed { get; }
        void UpdateInput();
    }
}