using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace CHAOSTRIGGER2
{
    public class TitleScreen : GameScreen
    {
        KeyboardState keyState;
        SpriteFont font;
        MenuManager menu;
        public TitleScreen(SpriteBatch spriteBatchLoad)
        {
            spriteBatch = spriteBatchLoad;
        }
        public override void LoadContent(ContentManager Content, InputManager inputManager)
        {
            base.LoadContent(Content, inputManager);
            if (font == null)
            {
                font = content.Load<SpriteFont>("SpriteFont1");
            }
            menu = new MenuManager();
            menu.LoadContent(content, "Title");
        }
        public override void UnloadContent()
        {
            base.UnloadContent();
            menu.UnloadContent();
        }
        public override void Update(GameTime gameTime)
        {
            inputManager.Update();
            menu.Update(gameTime, inputManager);
            keyState = Keyboard.GetState();
            if (keyState.IsKeyDown(Keys.Enter))
            {
                ScreenManager.Instance.AddScreen(new SplashScreen(), inputManager);
            }
            ScreenManager.Instance.Update(gameTime);
        }
        public override void Draw()
        {
            menu.Draw(spriteBatch); 
        }
    }
}
