using System;
using System.Numerics;
using Veldrid;
using Veldrid.Sdl2;

namespace Enigma.Input
{
    public interface IInputable
    {
        InputSnapshot Snapshot { protected set; get; }
        Vector2 MouseDelta { protected set; get; }
        bool MouseVisible { get; set; }

        event Action<KeyEvent> OnKeyDown, OnKeyUp;
        event Action<MouseEvent> OnMouseDown, OnMouseUp;
        event Action<MouseMoveEventArgs> OnMouseMove;
        event Action<MouseWheelEventArgs> OnMouseScroll;

        void SetMousePosition(Vector2 position);
    }
}
