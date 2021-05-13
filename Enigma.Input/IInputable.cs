using System;
using System.Numerics;
using Veldrid;
using Veldrid.Sdl2;

namespace Enigma.Input
{
    public interface IInputable
    {
        public Vector2 MouseDelta { get; }
        public bool MouseVisible { get; set; }

        public event Action<KeyEvent> OnKeyDown, OnKeyUp;
        public event Action<MouseEvent> OnMouseDown, OnMouseUp;
        public event Action<MouseMoveEventArgs> OnMouseMove;
        public event Action<MouseWheelEventArgs> OnMouseScroll;

        public void SetMousePosition(Vector2 position);
    }
}
