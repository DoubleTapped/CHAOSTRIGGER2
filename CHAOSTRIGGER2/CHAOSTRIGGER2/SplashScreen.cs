using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CHAOSTRIGGER2
{
    public class SplashScreen : GameScreen
    {
        KeyboardState keyState;
        SpriteFont font;
        List<FadeAnimation> fade;
        List<Texture2D> images;
        int imageNumber;

        public SplashScreen(SpriteBatch spriteBatchLoad)
        {
            spriteBatch = spriteBatchLoad;
        }
        public override void LoadContent(ContentManager Content)
        {
            base.LoadContent(Content);
            if (font == null)
            {
                font = content.Load<SpriteFont>("SpriteFont1");
            }
            fade = new List<FadeAnimation>();
            images = new List<Texture2D>();
            imageNumber = 0;
            for (int i = 0; i < attributes.Count; i++)
            {
                for (int j = 0; j < attributes[i].Count; j++)
                {
                    switch (attributes[i][j])
                    {
                        case "Image":
                            images.Add(content.Load<Texture2D>(contents[i][j]));
                            fade.Add(new FadeAnimation());
                            break;
                    }
                }
            }
            for (int i = 0; i < fade.Count; i++)
            {
                fade[i].LoadContent(content, images[i], "", Vector2.Zero);
                fade[i].Scale = 3.08f;
                fade[i].IsActive = true;
            }
        }
        public override void UnloadContent()
        {
            base.UnloadContent();
        }
        public override void Update(GameTime gameTime)
        {
            keyState = Keyboard.GetState();
            if (keyState.IsKeyDown(Keys.Z))
            {
                ScreenManager.Instance.AddScreen(new TitleScreen(spriteBatch));
                Draw();
            }
            base.Update(gameTime);
        }
        public override void Draw()
        {
            spriteBatch.DrawString(font, "SplashScreen", new Vector2(100, 100), Color.Black);
        }
    }
}
