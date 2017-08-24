using Corale.Colore.Razer.Keyboard;
using System;

namespace Matrix
{
    static class KeyDefinitions
    {
        public const int Rows = 5;

        private static readonly Key[] Row1 = new Key[]
        {
            Key.Escape,
            Key.F1,
            Key.F2,
            Key.F3,
            Key.F4,
            Key.F5,
            Key.F6,
            Key.F7,
            Key.F8,
            Key.F9,
            Key.F10,
            Key.F11,
            Key.F12,
            Key.Insert,
            Key.Delete
        };

        private static readonly Key[] Row2 = new Key[]
        {
            Key.OemTilde,
            Key.D1,
            Key.D2,
            Key.D3,
            Key.D4,
            Key.D5,
            Key.D6,
            Key.D7,
            Key.D8,
            Key.D9,
            Key.D0,
            Key.OemMinus,
            Key.OemEquals,
            Key.Backspace
        };

        private static readonly Key[] Row3 = new Key[]
        {
            Key.Tab,
            Key.Q,
            Key.W,
            Key.E,
            Key.R,
            Key.T,
            Key.Y,
            Key.U,
            Key.I,
            Key.O,
            Key.P,
            Key.OemLeftBracket,
            Key.OemRightBracket,
            Key.OemBackslash
        };

        private static readonly Key[] Row4 = new Key[]
        {
            Key.CapsLock,
            Key.A,
            Key.S,
            Key.D,
            Key.F,
            Key.G,
            Key.H,
            Key.J,
            Key.K,
            Key.L,
            Key.OemSemicolon,
            Key.OemApostrophe,
            Key.Enter
        };

        private static readonly Key[] Row5 = new Key[]
        {
            Key.LeftShift,
            Key.Z,
            Key.X,
            Key.C,
            Key.V,
            Key.B,
            Key.N,
            Key.M,
            Key.OemComma,
            Key.OemPeriod,
            Key.OemSlash,
            Key.RightShift
        };

        public static Key[] GetKeyDefinition(int rowNumber)
        {
            switch (rowNumber)
            {
                case 1:
                    return Row1;
                case 2:
                    return Row2;
                case 3:
                    return Row3;
                case 4:
                    return Row4;
                case 5:
                    return Row5;
                default:
                    throw new IndexOutOfRangeException();
            }
        }
    }
}
