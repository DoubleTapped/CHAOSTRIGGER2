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
    public class GameScreen
    {
        protected ContentManager content;
        public SpriteBatch spriteBatch;
        protected List<List<string>> attributes, contents;
      
        public virtual void Initialize() 
        {


        }
        public virtual void LoadContent(ContentManager Content)
        {
            content = new ContentManager(Content.ServiceProvider, "Content");
        }
        public virtual void UnloadContent()
        {
            content.Unload();
        }
        public virtual void Update(GameTime gameTime)
        {

        }
        public virtual void Draw()
        {

        }
    }
}
