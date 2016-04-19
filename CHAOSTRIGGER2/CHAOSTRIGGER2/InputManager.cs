using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace CHAOSTRIGGER2
{
    public class InputManager
    {
        KeyboardState prevKeyState, keyState;
        public KeyboardState PrevKeyState
        {
            get { return prevKeyState; }
            set { prevKeyState = value; }
        }
        public KeyboardState KeyState
        {
            get { return keyState; }
            set { keyState = value; }
        }

        public void Update()
        {
            prevKeyState = keyState;
            keyState = Keyboard.GetState();
        }

        public bool KeyPressed(Keys key)
        {
            if(keyState.IsKeyDown(key) && prevKeyState.IsKeyUp(key))
                return true;
            return false;
        }
        public bool Keypressed(params Keys[] key)
        {

        }
    }
}
