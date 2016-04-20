using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace CHAOSTRIGGER2
{
    public class SpriteSheetAnimation : Animation
    {

        int frameCounter;
        int switchFrame;

        Vector2 frames;

        public override void LoadContent(ContentManager Content, Texture2D image, string text, Vector2 position)
        {
            base.LoadContent(Content, image, text, position);
            frameCounter = 0;
            switchFrame = 100;
            
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }
        public override void Update(GameTime gameTime)
        {
            if(isActive)
            {
                frameCounter += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
                if(frameCounter >= switchFrame)
                {
                    frameCounter = 0;
                }
            }
            else
            {
                frameCounter = 0;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
