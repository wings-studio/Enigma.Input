using System;
using System.Collections.Generic;
using System.Numerics;
using Veldrid;
using Veldrid.Sdl2;

namespace Enigma.Input
{
    public static class Input
    {
        public static Vector2 MouseDelta { get; }
        public static bool MouseVisible { get; set; }

        public static event Action<KeyEvent> OnKeyDown, OnKeyUp;
        public static event Action<MouseEvent> OnMouseDown, OnMouseUp;
        public static event Action<MouseMoveEventArgs> OnMouseMove;
        public static event Action<MouseWheelEventArgs> OnMouseScroll;

        private static readonly List<IInputable> inputables = new ();
        private static readonly List<InputSnapshot> snapshots = new ();

        public static void AddInputable(IInputable inputable)
        {
            inputables.Add(inputable);
        }

        public static void Update()
        {
            snapshots.Clear();

            foreach (IInputable i in inputables)
            {
                snapshots.Add(i.Snapshot);
            }
        }

        public static bool IsKeyDown(Key key)
        {
            foreach (InputSnapshot s in snapshots)
            {
                foreach (KeyEvent e in s.KeyEvents)
                {
                    if (e.Key == key)
                        return e.Down;
                }
            }
            return false;
        }

        public static void SetMousePosition(Vector2 position)
        {
            foreach (IInputable i in inputables)
                i.SetMousePosition(position);
        }

        public static void SetMousePosition(int x, int y)
        {
            SetMousePosition(new Vector2(x, y));
        }
    }
}
