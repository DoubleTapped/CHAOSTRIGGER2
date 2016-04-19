﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace CHAOSTRIGGER2
{
    public class SplashScreen : GameScreen
    {
        KeyboardState keyState;
        SpriteFont font;
        List<FadeAnimation> fade;
        List<Texture2D> images;
        List<SoundEffect> sounds;
        FileManager fileManager;
        int imageNumber;

        public override void LoadContent(ContentManager Content)
        {
            base.LoadContent(Content);
            if (font == null)
            {
                font = Content.Load<SpriteFont>("SpriteFont1");
            }
            fileManager = new FileManager();
            fade = new List<FadeAnimation>();
            images = new List<Texture2D>();
            sounds = new List<SoundEffect>();
            fileManager.LoadContent("Load/Splash.ct", attributes, contents);
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
                        case "Sound":
                            sounds.Add(content.Load<SoundEffect>(contents[i][j]));
                            break;
                    }
                }
            }
            for (int i = 0; i < fade.Count; i++)
            {
                fade[i].LoadContent(Content, images[i], "", Vector2.Zero);
                fade[i].Scale = 1.08f;
                fade[i].IsActive = true;
            }
        }
        public override void UnloadContent()
        {
            base.UnloadContent();
            fileManager = null;
        }
        public override void Update(GameTime gameTime)
        {
            keyState = Keyboard.GetState();
            if (keyState.IsKeyDown(Keys.Enter))
            {
                ScreenManager.Instance.AddScreen(new TitleScreen(spriteBatch));
            }
            for (int i = 0; i < fade.Count; i++)
            {
                fade[imageNumber].Update(gameTime);
                base.Update(gameTime);
            }
        }
        public override void Draw()
        {
            fade[imageNumber].Draw(spriteBatch);
        }
    }
}


