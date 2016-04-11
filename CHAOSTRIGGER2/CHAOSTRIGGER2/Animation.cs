using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace CHAOSTRIGGER2
{
    public class Animation
    {
        protected Texture2D image;
        protected string text;
        protected SpriteFont font;
        protected Color color;
        protected Rectangle sourceRect;
        protected float rotation;
        protected float scale;
        protected float axis;
        protected Vector2 position;
        protected Vector2 origin;
        protected ContentManager content;
        protected bool isActive;
        public SpriteBatch spriteBatch;
        protected float alpha;

        public virtual float Alpha
        {
            get { return alpha; }
            set { alpha = value; }
        }

        public bool IsActive
        {
            set { isActive = value; }
            get { return isActive; }
        }

        public float Scale
        {
            set { scale = value; }
        }
        public float ActivateValue
        {
            get { return ActivateValue; }
            set { ActivateValue = value; }
        }

        public virtual void LoadContent(ContentManager Content, Texture2D image, string text, Vector2 position)
        {
            content = new ContentManager(Content.ServiceProvider, "Content");
            this.image = image;
            this.text = text;
            this.position = position;
            if (text != String.Empty)
            {
                font = content.Load<SpriteFont>("AnimationFont");
                color = new Color(114, 77, 225);
            }
            if (image != null)
            {
                sourceRect = new Rectangle(0, 0, image.Width, image.Height);
                rotation = 0.0f;
                axis = 0.0f;
                scale = alpha = 1.0f;
                isActive = false;
            }
        }
        public virtual void UnloadContent()
        {
            content.Unload();
            text = String.Empty;
            position = Vector2.Zero;
            sourceRect = Rectangle.Empty;
            image = null;
        }
        public virtual void Draw()
        {
            if (image != null)
            {
                origin = new Vector2(sourceRect.Width / 2, sourceRect.Height / 2);
                spriteBatch.Draw(image, position + origin, sourceRect, Color.White * alpha, rotation, origin, scale, SpriteEffects.None, 0.0f);
            }
            if (text != String.Empty)
            {
                origin = new Vector2(font.MeasureString(text).X / 2, font.MeasureString(text).Y / 2);
                spriteBatch.DrawString(font, text, position + origin, color * alpha, rotation, origin, scale, SpriteEffects.None, 0.0f);
            }
        }
        public virtual void Update(GameTime gameTime)
        {

        }
    }
}
