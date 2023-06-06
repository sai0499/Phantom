using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phantom
{
    public class InputManager
    {
        private static KeyboardState previousKeyboardState;
        private static KeyboardState currentKeyboardState;

        public static void Update()
        {
            previousKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();
        }

        public static bool IsKeyPressed(Keys key)
        {
            return currentKeyboardState.IsKeyDown(key) && previousKeyboardState.IsKeyUp(key);
        }

        public static bool IsKeyDown(Keys key)
        {
            return currentKeyboardState.IsKeyDown(key);
        }
    }
}
